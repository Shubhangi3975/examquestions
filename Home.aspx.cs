using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exam
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\user1\documents\visual studio 2013\Projects\exam\exam\App_Data\Database1.mdf;Integrated Security=True");
            String selectq = "select * from Student";
            SqlCommand cmd = new SqlCommand(selectq, con);
            con.Open();
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();

        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("login.aspx");
            
        }

       
    }
}