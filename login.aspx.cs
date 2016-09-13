using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exam
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\user1\documents\visual studio 2013\Projects\exam\exam\App_Data\Database1.mdf;Integrated Security=True");
                String selectq = "select Name from Student";
                SqlCommand cmd = new SqlCommand(selectq, con);
                con.Open();
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    DropDownList1.Items.Add(rdr["Name"].ToString());
                }
                con.Close();
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user, pwd;
            user = DropDownList1.SelectedItem.Text;
            pwd = TextBox2.Text;
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\user1\documents\visual studio 2013\Projects\exam\exam\App_Data\Database1.mdf;Integrated Security=True");
            
            //con.Open();

            if (user==pwd)
                Response.Redirect("Home.aspx");
            else
                Console.WriteLine("INvalid");
        }
    }
}