<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giriş.aspx.cs" Inherits="MakroStok.Giriş" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="128px" placeholder="Kullanıcı Sicili"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="128px" textmode="Password" placeholder="Parola"></asp:TextBox>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="132px">
                <asp:ListItem>Tam Yetkili</asp:ListItem>
                <asp:ListItem>İzleme</asp:ListItem>
                <asp:ListItem>Veri Giriş</asp:ListItem>
            </asp:DropDownList>
            <br></br>
            <asp:Button ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
