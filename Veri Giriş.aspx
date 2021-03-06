<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Veri Giriş.aspx.cs" Inherits="MakroStok.Veri_Giriş" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="refresh" content="60"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LogStatus">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Oturumu Kapat" OnClick="Button2_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">Şifre Değiştir</asp:LinkButton>
            <hr />
        </div>
        <div id="stok ekleme">
            <h3>Ürün Stoğu Ekleme:</h3>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Ürün Kodu"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Ürün Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Ürün Boyutu"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" placeholder="Kaç Adet"></asp:TextBox>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Ekle" OnClick="Button1_Click" />
            </p>
            <h4>Son Eklenen Ürünler:</h4>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Ürün Kodu" HeaderText="Ürün Kodu" SortExpression="Ürün Kodu" />
                    <asp:BoundField DataField="Ürün Adı" HeaderText="Ürün Adı" SortExpression="Ürün Adı" />
                    <asp:BoundField DataField="Ürün Boyutu" HeaderText="Ürün Boyutu" SortExpression="Ürün Boyutu" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StokConnectionString %>" SelectCommand="SELECT UrunKodu AS N'Ürün Kodu', UrunAdı AS N'Ürün Adı', UrunBoyutu AS 'Ürün Boyutu' FROM STOK.URUNSTOK"></asp:SqlDataSource>
            <hr />
        </div>
        <div id="üretim ekleme">
            <h3>Üretime Ekleme:</h3>
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Üretim Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Üretim Boyutu"></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" placeholder="Kaç Adet"></asp:TextBox>
            <p>
                <asp:Button ID="Button3" runat="server" Text="Ekle" OnClick="Button3_Click" />
            </p>
            <h4>Son Eklenen Üretimler:</h4>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="Üretim Adı" HeaderText="Üretim Adı" SortExpression="Üretim Adı" />
                    <asp:BoundField DataField="Üretim Boyutu" HeaderText="Üretim Boyutu" SortExpression="Üretim Boyutu" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StokConnectionString %>" SelectCommand="SELECT UretimAdı AS N'Üretim Adı', UretimBoyutu AS N'Üretim Boyutu' FROM STOK.URETIM"></asp:SqlDataSource>
            <hr />
        </div>
        <div id="üretim stoklama">
            <h3>Üretim Stoğu Ekleme:</h3>
            <asp:TextBox ID="TextBox6" runat="server" placeholder="Üretim Stok Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox9" runat="server" placeholder="Kaç Adet"></asp:TextBox>
            <p>
                <asp:Button ID="Button4" runat="server" Text="Ekle" OnClick="Button4_Click" />
            </p>
            <h4>Son Eklenen Üretim Stokları:</h4>
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                <Columns>
                    <asp:BoundField DataField="Üretim Stok Adı" HeaderText="Üretim Stok Adı" SortExpression="Üretim Stok Adı" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:StokConnectionString %>" SelectCommand="SELECT UretStokAdı AS N'Üretim Stok Adı' FROM STOK.URETIMSTOK"></asp:SqlDataSource>
            <hr />
        </div>
        <div id="ürün kutulama">
            <h3>Ürün Kutulama:</h3>
            <asp:TextBox ID="TextBox10" runat="server" placeholder="Ürün Kodu"></asp:TextBox>
            <asp:TextBox ID="TextBox11" runat="server" placeholder="Ürün Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox12" runat="server" placeholder="Ürün Boyutu"></asp:TextBox>
            <asp:TextBox ID="TextBox13" runat="server" placeholder="Üretim Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox14" runat="server" placeholder="Üretim Boyutu"></asp:TextBox>
            <asp:TextBox ID="TextBox15" runat="server" placeholder="0: Çıkar / 1: Kutula"></asp:TextBox>
            <asp:TextBox ID="TextBox16" runat="server" placeholder="Kaç Adet"></asp:TextBox>
            <p>
                <asp:Button ID="Button5" runat="server" Text="Yap" OnClick="Button5_Click" />
            </p>
            <h4>Kutulanmış Ürün Adedi:</h4>
            <asp:TextBox ID="TextBox17" runat="server" placeholder="Ürün Kodu"></asp:TextBox>
            <asp:TextBox ID="TextBox18" runat="server" placeholder="Ürün Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox19" runat="server" placeholder="Ürün Boyutu"></asp:TextBox>
            <p>
                <asp:Button ID="Button6" runat="server" Text="Göster" OnClick="Button6_Click" />
            </p>
            <asp:GridView ID="GridView4" runat="server"></asp:GridView>
            <hr />
        </div>
        <div id="mal işleme">
            <h3>Mal İşleme:</h3>
            <asp:TextBox ID="TextBox20" runat="server" placeholder="Üretim Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox21" runat="server" placeholder="Üretim Boyutu"></asp:TextBox>
            <asp:TextBox ID="TextBox22" runat="server" placeholder="Üretim Stok Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox23" runat="server" placeholder="0: İptal / 1: Punto"></asp:TextBox>
            <asp:TextBox ID="TextBox24" runat="server" placeholder="0: İptal / 1: Kapla"></asp:TextBox>
            <asp:TextBox ID="TextBox25" runat="server" placeholder="0: İptal / 1: Lastikle"></asp:TextBox>
            <asp:TextBox ID="TextBox28" runat="server" placeholder="Kaç Adet"></asp:TextBox>
            <p>
                <asp:Button ID="Button7" runat="server" Text="Yap" OnClick="Button7_Click" />
            </p>
            <h4>Puntolanmış Mal Adedi:</h4>
            <asp:TextBox ID="TextBox26" runat="server" placeholder="Üretim Stok Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox27" runat="server" placeholder="0: İşlenmemiş / 1: İşlenmiş"></asp:TextBox>
            <p>
                <asp:Button ID="Button8" runat="server" Text="Göster" OnClick="Button8_Click" />
            </p>
            <asp:GridView ID="GridView5" runat="server"></asp:GridView>
            <h4>Kaplanmış Mal Adedi:</h4>
            <asp:TextBox ID="TextBox29" runat="server" placeholder="Üretim Stok Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox30" runat="server" placeholder="0: İşlenmemiş / 1: İşlenmiş"></asp:TextBox>
            <p>
                <asp:Button ID="Button9" runat="server" Text="Göster" OnClick="Button9_Click" />
            </p>
            <asp:GridView ID="GridView6" runat="server"></asp:GridView>
            <h4>Lastiklenmiş Mal Adedi:</h4>
            <asp:TextBox ID="TextBox31" runat="server" placeholder="Üretim Stok Adı"></asp:TextBox>
            <asp:TextBox ID="TextBox32" runat="server" placeholder="0: İşlenmemiş / 1: İşlenmiş"></asp:TextBox>
            <p>
                <asp:Button ID="Button10" runat="server" Text="Göster" OnClick="Button10_Click" />
            </p>
            <asp:GridView ID="GridView7" runat="server"></asp:GridView>
            <hr />
        </div>          
    </form>
</body>
</html>
