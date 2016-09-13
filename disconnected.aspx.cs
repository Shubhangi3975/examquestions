using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;

namespace exam
{
    public partial class disconnected : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\user1\documents\visual studio 2013\Projects\exam\exam\App_Data\Database1.mdf;Integrated Security=True");
            String selectq = "select * from Student";
            SqlCommand cmd = new SqlCommand(selectq, con);
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataSet dbStu=new DataSet();
           
           
                con.Open();
                adapter.Fill(dbStu, "Student");

            foreach(DataRow row in dbStu.Tables["Student"].Rows)
            {
                ListItem newItem = new ListItem();
                newItem.Text = row["Id"] + ";" + row["Name"];
                newItem.Value = row["Id"].ToString();
                ListBox1.Items.Add(newItem);
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string connectionString { get; set; }
    }
}