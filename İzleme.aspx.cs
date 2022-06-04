using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace MakroStok
{
    public partial class İzleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["test"]))
                Label1.Text = "Aktif Kullanıcı: " + Request.QueryString["test"];
            else
            {
                Label1.Text = "Bilinmeyen Kullanıcı";
            }
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Giriş.aspx");
        }
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Şifre Değiştir.aspx?test=" + Label1.Text);
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox17.Text == "")
                MessageBox.Show("Ürün kodu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox18.Text == "")
                MessageBox.Show("Ürün adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox19.Text == "")
                MessageBox.Show("Ürün boyutu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pKUTULANMIS_URUN @urunkodu = @TextBox17, @urunadı = @TextBox18, @urunboyutu = @TextBox19", con1);
                    cmd1.Parameters.AddWithValue("@TextBox17", TextBox17.Text);
                    cmd1.Parameters.AddWithValue("@TextBox18", TextBox18.Text);
                    cmd1.Parameters.AddWithValue("@TextBox19", TextBox19.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con1.Close();

                    GridView4.DataSource = dt;
                    GridView4.DataBind();

                    MessageBox.Show("Kutulanmış ürünler getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (TextBox26.Text == "")
                MessageBox.Show("Üretim stok adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox27.Text == "")
                MessageBox.Show("İşlem giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pPUNTO_MAL @uretimstokadı = @TextBox26, @punto = @TextBox27", con1);
                    cmd1.Parameters.AddWithValue("@TextBox26", TextBox26.Text);
                    cmd1.Parameters.AddWithValue("@TextBox27", TextBox27.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con1.Close();

                    GridView5.DataSource = dt;
                    GridView5.DataBind();

                    MessageBox.Show("İşlenmiş ürünler getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (TextBox29.Text == "")
                MessageBox.Show("Üretim stok adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox30.Text == "")
                MessageBox.Show("İşlem giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pKAPLA_MAL @uretimstokadı = @TextBox29, @kapla = @TextBox30", con1);
                    cmd1.Parameters.AddWithValue("@TextBox29", TextBox29.Text);
                    cmd1.Parameters.AddWithValue("@TextBox30", TextBox30.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con1.Close();

                    GridView6.DataSource = dt;
                    GridView6.DataBind();

                    MessageBox.Show("İşlenmiş ürünler getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (TextBox31.Text == "")
                MessageBox.Show("Üretim stok adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox32.Text == "")
                MessageBox.Show("İşlem giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pLASTIK_MAL @uretimstokadı = @TextBox31, @lastik = @TextBox32", con1);
                    cmd1.Parameters.AddWithValue("@TextBox31", TextBox31.Text);
                    cmd1.Parameters.AddWithValue("@TextBox32", TextBox32.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con1.Close();

                    GridView7.DataSource = dt;
                    GridView7.DataBind();

                    MessageBox.Show("İşlenmiş ürünler getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
    }
}