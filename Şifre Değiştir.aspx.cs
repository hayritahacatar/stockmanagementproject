using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace MakroStok
{
    public partial class Şifre_Değiştir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["test"]))
                Label1.Text = "" + Request.QueryString["test"];
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update USERLIST set Passwordd = @TextBox1 where USERLIST.CompanyID = '" + Label1.Text.Remove(0, 17) + "'", con);
            cmd.Parameters.AddWithValue("@TextBox1", TextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Şifre değiştirme işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}