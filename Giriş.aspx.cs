using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace MakroStok
{
    public partial class Giriş : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StokConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOK.USERLIST where CompanyID=@TextBox1 and Passwordd=@TextBox2 and UserType=@DropDownList1", con);
            cmd.Parameters.AddWithValue("@TextBox1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@TextBox2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@DropDownList1", DropDownList1.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            if (dt.Rows.Count > 0)
            {
                if (DropDownList1.Text == "Tam Yetkili")
                    Response.Redirect("Tam Yetkili.aspx?test=" + TextBox1.Text);
                if (DropDownList1.Text == "İzleme")
                    Response.Redirect("İzleme.aspx?test=" + TextBox1.Text);
                if (DropDownList1.Text == "Veri Giriş")
                    Response.Redirect("Veri Giriş.aspx?test=" + TextBox1.Text);
            }
            else
            {
                MessageBox.Show("Yetkisiz Giriş...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}