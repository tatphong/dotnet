<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_form.aspx.cs" Inherits="WebserviceDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 111px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblName" runat="server" Text="Enter Your Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnOK" runat="server" OnClick="Button1_Click" Text="OK" />
        </p>
        <p>
            &nbsp;</p>
        <p>
    <asp:Label ID="lblHello" runat="server" Text="Hello World"></asp:Label>
        </p>
    </form>
    </body>
</html>
