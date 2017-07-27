using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace rc
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Your Student Card Number' ", true);

            }
        }

        
           
        protected void start_Click(object sender, EventArgs e)
        {
         
          MySqlConnection    con = new MySqlConnection("Server = sql5.freesqldatabase.com; Database = sql5118801; Uid = sql5118801; Password = ZFHhEzCPwF");

           
                con.Open();

            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = ("SELECT * FROM RCNS");

            MySqlDataReader reader = null;

            reader = cmd.ExecuteReader();
            List<string> names = new List<string>();
            List<string> locations = new List<string>();

            string location = "";
            string name = "";
            string value = TextBox1.Text;

            int count = 0;
            while (reader.Read())
            {
                names.Add(reader["student_number"].ToString());
                name = reader["student_number"].ToString();
                location=reader["Location"].ToString();
                locations.Add(  reader["Location"].ToString());

                count++;

                if (name == value)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Card " + TextBox1.Text + " is at " + location + " Campus')", true);

                }


            }

           
            for (int r = 0; r < count; r++)
            {
                if (names[r]!=value)
                {
                   // location.Add( reader["Location"].ToString());

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Card Not Found')", true);


                    break;


                }

        


            }
             /*for (int r=0;r<count;r++){


            }
            try{}

             catch (Exception ex)
                   {
                       Exception ex2 = ex;
                       string errorMessage = string.Empty;
                       while (ex2 != null)
                       {
                           errorMessage += ex2.ToString();
                           ex2 = ex2.InnerException;
                       }
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Recheck')", true);
                   }

                   finally
                   {

                       con.Close();
                   }*/
        }

        }
    }
