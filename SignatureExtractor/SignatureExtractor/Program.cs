// See https://aka.ms/new-console-template for more information
//using iTextSharp.text.pdf;
using iText.Forms;
using iText.Kernel.Pdf;
using iText.Signatures;
using SignatureExtractor;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

Console.WriteLine("Hello, World!");

//PdfLoadedDocument document = new PdfLoadedDocument(File.ReadAllBytes("Tai lieu dac ta APIs CEP SGB V1.1 signed.pdf"), true);

//Get the signature field from PdfLoadedDocument form field collection.
//PdfLoadedSignatureField signatureField = document.Form.Fields[0] as PdfLoadedSignatureField;
//PdfSignature signature = signatureField.Signature;

////Extract the signature information.
//Console.WriteLine("Digitally Signed by: " + signature.Certificate.IssuerName);
//Console.WriteLine("Valid From: " + signature.Certificate.ValidFrom);
//Console.WriteLine("Valid To: " + signature.Certificate.ValidTo);
//Console.WriteLine("Hash Algorithm : " + signature.Settings.DigestAlgorithm);
//Console.WriteLine("Cryptographics Standard : " + signature.Settings.CryptographicStandard);
//Console.WriteLine("Subject Name : " + signature.Certificate.IssuerName);


//*************************************************************************
//Validate("Tai lieu dac ta APIs CEP SGB V1.1 signed.pdf");
Validate("Payoo.pdf");


//X509Certificate2? GetPublicKey(string filePath)
//{
//    //X509Certificate2 cert = null;
//    using var reader = new PdfReader(filePath);
//    var fields = reader.AcroFields;

//    Org.BouncyCastle.X509.X509Certificate[]? certs = null;
//    bool isSignValid = false;
//    foreach (var field in fields.Fields)
//    {
//        Console.WriteLine($"{field.Key}");
//        certs = fields.VerifySignature(field.Key).Certificates;
//        isSignValid = fields.VerifySignature(field.Key).Verify();
//        Console.WriteLine($"Signature validation: {isSignValid}");
//        foreach (var cert in certs)
//        {
//            Console.WriteLine($"{cert}");
//        }
//        // Console.WriteLine("validated: " + fields.VerifySignature(field.Key).Verify());

//    }
//    return certs is null ? null : new(certs[90].GetEncoded());
//}

void Validate(string filePath)
{
    X509Store store = new(StoreName.Root, StoreLocation.CurrentUser, OpenFlags.ReadOnly);
    Console.WriteLine("Store name: {0}", store.Name);
    var certCollection = store.Certificates;
    foreach (var storeCert in certCollection)
    {
        Console.WriteLine("> Certificate name: {0}", storeCert.Subject);
    }

    X509Certificate2[] certs = GetPublicKeys(filePath) ?? throw new NullReferenceException();

    foreach (var cert in certs)
    {
        var chain = new X509Chain();
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        chain.ChainPolicy.ExtraStore.AddRange(certCollection);
        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid;// | X509VerificationFlags.AllowUnknownCertificateAuthority;
        var isValid = chain.Build(cert);
        Console.WriteLine("Cert Validated: " + isValid);
        Console.WriteLine("Signature Validated: " + isValid);
    }
}

Console.ReadLine();


void SaveFileStream(String path, Stream stream)
{
    var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
    stream.CopyTo(fileStream);
    fileStream.Dispose();
}

void GetSystemCert()
{
    X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    try
    {
        store.Open(OpenFlags.OpenExistingOnly);

        Console.WriteLine("Yes    {0,4}  {1}, {2}",
            store.Certificates.Count, store.Name, store.Location);
    }
    catch (CryptographicException)
    {
        Console.WriteLine("No           {0}, {1}",
            store.Name, store.Location);
    }
}

X509Certificate2[] GetPublicKeys(string filePath)
{
    using var reader = new PdfReader(filePath);
    using var document = new PdfDocument(reader);
    var fields = PdfAcroForm.GetAcroForm(document, false);

    if (fields is null) return Array.Empty<X509Certificate2>();

    var signature = new SignatureUtil(document);

    List<X509Certificate2> certs = new();
    foreach (var name in signature.GetSignatureNames())
    {
        Console.WriteLine($"{name}");
        var chain = signature.ReadSignatureData(name).GetCertificates();
        foreach (var cert in chain)
        {
            Console.WriteLine($"{cert}");
        }
        certs.Add(new(chain[0].GetEncoded()));
    }
    return certs.ToArray();
}