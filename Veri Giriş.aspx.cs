using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace MakroStok
{
    public partial class Veri_Giriş : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["test"]))
                Label1.Text = "Aktif Kullanıcı: " + Request.QueryString["test"];
            else
            {
                Label1.Text = "Bilinmeyen Kullanıcı";
            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                MessageBox.Show("Ürün kodunu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox2.Text == "")
                MessageBox.Show("Ürün adını giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox3.Text == "")
                MessageBox.Show("Ürün boyutunu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox7.Text == "")
                MessageBox.Show("Ürün adedini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pURUNSTOK_EKLEME @urunkodu = @TextBox1, @urunadı = @TextBox2, @urunboyutu = @TextBox3", con1);
                    cmd1.Parameters.AddWithValue("@TextBox1", TextBox1.Text);
                    cmd1.Parameters.AddWithValue("@TextBox2", TextBox2.Text);
                    cmd1.Parameters.AddWithValue("@TextBox3", TextBox3.Text);

                    for (int i = 0; i < Convert.ToInt32(TextBox7.Text); i++)
                        cmd1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Kayıt işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text == "")
                MessageBox.Show("Üretim adını giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox5.Text == "")
                MessageBox.Show("Üretim boyutunu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox8.Text == "")
                MessageBox.Show("Üretim adedini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pURETIM_EKLEME @uretimadı = @TextBox4, @uretimboyutu = @TextBox5", con1);
                    cmd1.Parameters.AddWithValue("@TextBox4", TextBox4.Text);
                    cmd1.Parameters.AddWithValue("@TextBox5", TextBox5.Text);

                    for (int i = 0; i < Convert.ToInt32(TextBox8.Text); i++)
                        cmd1.ExecuteNonQuery(); con1.Close();
                    MessageBox.Show("Kayıt işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox6.Text == "")
                MessageBox.Show("Üretim stok adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox9.Text == "")
                MessageBox.Show("Üretim stoğu adedini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pURETIMSTOK_EKLEME @uretimstokadı = @TextBox6", con1);
                    cmd1.Parameters.AddWithValue("@TextBox6", TextBox6.Text);

                    for (int i = 0; i < Convert.ToInt32(TextBox9.Text); i++)
                        cmd1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Kayıt işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            GridView3.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TextBox10.Text == "")
                MessageBox.Show("Ürün kodu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox11.Text == "")
                MessageBox.Show("Ürün adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox12.Text == "")
                MessageBox.Show("Ürün boyutu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox13.Text == "")
                MessageBox.Show("Üretim adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox14.Text == "")
                MessageBox.Show("Üretim boyutu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox15.Text == "")
                MessageBox.Show("İşlemi giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox16.Text == "")
                MessageBox.Show("İşlem adedini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pURUN_KUTULAMA @urunkodu = @TextBox10, @urunadı = @TextBox11, @urunboyutu = @TextBox12, @uretimadı = @TextBox13, @uretimboyutu = @TextBox14, @kutu = @TextBox15", con1);
                    cmd1.Parameters.AddWithValue("@TextBox10", TextBox10.Text);
                    cmd1.Parameters.AddWithValue("@TextBox11", TextBox11.Text);
                    cmd1.Parameters.AddWithValue("@TextBox12", TextBox12.Text);
                    cmd1.Parameters.AddWithValue("@TextBox13", TextBox13.Text);
                    cmd1.Parameters.AddWithValue("@TextBox14", TextBox14.Text);
                    cmd1.Parameters.AddWithValue("@TextBox15", TextBox15.Text);

                    for (int i = 0; i < Convert.ToInt32(TextBox16.Text); i++)
                        cmd1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Kayıt işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception error1)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu." + error1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
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

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (TextBox20.Text == "")
                MessageBox.Show("Üretim adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox21.Text == "")
                MessageBox.Show("Üretim boyutu giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox22.Text == "")
                MessageBox.Show("Üretim stok adı giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox23.Text == "")
                MessageBox.Show("Punto işlemini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox24.Text == "")
                MessageBox.Show("Kaplama işlemini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox25.Text == "")
                MessageBox.Show("Lastikleme işlemini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else if (TextBox28.Text == "")
                MessageBox.Show("İşlem adedini giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("EXEC STOK.pURETIM_ISLEMI @uretimadı = @TextBox20, @uretimboyutu = @TextBox21, @uretimstokadı = @TextBox22, @punto = @TextBox23, @kapla = @TextBox24, @lastik = @TextBox25", con1);
                    cmd1.Parameters.AddWithValue("@TextBox20", TextBox20.Text);
                    cmd1.Parameters.AddWithValue("@TextBox21", TextBox21.Text);
                    cmd1.Parameters.AddWithValue("@TextBox22", TextBox22.Text);
                    cmd1.Parameters.AddWithValue("@TextBox23", TextBox23.Text);
                    cmd1.Parameters.AddWithValue("@TextBox24", TextBox24.Text);
                    cmd1.Parameters.AddWithValue("@TextBox25", TextBox25.Text);

                    for (int i = 0; i < Convert.ToInt32(TextBox28.Text); i++)
                        cmd1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("Kayıt işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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