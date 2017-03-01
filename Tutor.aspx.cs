using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Tutor : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Server = tcp:migosrvr.database.windows.net, 1433; Database=MigoDB;Uid=lklash@migosrvr; Pwd=Pizza123!;Encrypt=yes;TrustServerCertificate=no;Connection Timeout = 30;");
    


        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT FirstName FROM SalesLT.Customer where (FirstName like '%' + @search + '%')";
            SqlCommand xp = new SqlCommand(query, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = TextBox1.Text;

            con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds, "FirstName");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            con.Close();
        }
    }
}