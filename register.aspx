<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="index.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Please enter your data in the fields below.
        <br />
        <br />
        Username
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Password
        <asp:TextBox ID="TxtPass1" runat="server"></asp:TextBox>
        <br />
        <br />
        Password again
        <asp:TextBox ID="TxtPass2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Create Account" />
    
    </div>
        <asp:Label ID="LblError" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LblTest" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
