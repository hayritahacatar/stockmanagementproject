<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Şifre Değiştir.aspx.cs" Inherits="MakroStok.Şifre_Değiştir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LogStatus">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Oturumu Kapat" OnClick="Button2_Click" />
            <hr />
        
        <div id="cpass">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Yeni şifrenizi giriniz"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Değiştir" OnClick="Button3_Click" />
            <hr />
        </div>
    </form>
</body>
</html>
