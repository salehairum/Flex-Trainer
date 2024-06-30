using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class loginAdmin : Form
    {
        int adminID;
        public loginAdmin()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            SqlCommand cmd, cmd2, cmd3;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string query = "Select aPassword from Account where username= '" + un + "' and aType='gymowner'";
            cmd = new SqlCommand(query, conn);
            object password = cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (password!=null && (password.ToString() == null || password.ToString() != pass))
            {
                MessageBox.Show("Invalid password");
            }
            else
            {
                string query2 = "Select accountID from Account where username= '" + un + "' and aType='admin' and apassword='" + pass + "'";
                cmd2 = new SqlCommand(query2, conn);
                object accountid = cmd2.ExecuteScalar();
                int accountId = Convert.ToInt32(accountid);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                string query3 = "Select adminID from Admin WHERE accountId = " + accountId;
                cmd3 = new SqlCommand(query3, conn);
                object gymownerid = cmd3.ExecuteScalar();
                adminID = Convert.ToInt32(gymownerid);
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();

                conn.Close();
                this.Hide();
                admin form = new admin(adminID);
                //admin form = new admin(adminID);
                form.Show();
                form.FormClosed += (s, argc) => this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signupAdmin form = new signupAdmin();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();

        }
        private void loginAdmin_Load(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}
