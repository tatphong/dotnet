using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SignatureExtractor
{
    public class PDFExtractorServices
    {
        internal (byte[] sign,byte[] data) GetSignValue(string inputPath)
        {
            string[] lines = System.IO.File.ReadAllLines(inputPath);
            int[] rangeIdx = new int[4];

            for (int i = lines.Length-1; i>=0; --i)
            {
                if (!lines[i].Contains("ByteRange ["))
                    continue;

                string byteRange = lines[i].Split("ByteRange [")[1];   
                if (byteRange.Length > 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        rangeIdx[j] = Int32.Parse(byteRange.Split(" ")[j]);
                        Console.WriteLine(rangeIdx[j]);
                    }
                    break;
                }
            }

            byte[] inputData = File.ReadAllBytes(inputPath);
            byte[] signvalue = inputData[(rangeIdx[1] +1)..(rangeIdx[2] -1)];
            List<byte> arr = new(inputData[0..(rangeIdx[1]+1)]);
            arr.Concat(inputData[(rangeIdx[2]-1)..(rangeIdx[2]+rangeIdx[3])]);

            Console.WriteLine("haha: " + Encoding.UTF8.GetString(inputData[(rangeIdx[2]-1)..(rangeIdx[2] + rangeIdx[3] )]));
            //byte[] data = inputData[0..rangeIdx[1]];
            return (Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(signvalue).Split("00000")[0]), arr.ToArray());
        }

        internal bool CheckValidate(byte[] signValue, byte[] data, string certPath)
        {
            //var sign = IText.GetSignature(filePath);
            var pub = new X509Certificate2(certPath);
            var rsa = pub.GetRSAPublicKey();
            return rsa.VerifyData(data, signValue, System.Security.Cryptography.HashAlgorithmName.SHA256, System.Security.Cryptography.RSASignaturePadding.Pkcs1);
        }
    }
}
