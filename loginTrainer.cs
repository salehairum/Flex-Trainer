using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace project
{
    public partial class loginTrainer : Form
    {
        int trainerID;
        public loginTrainer()
        {
            InitializeComponent();
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlCommand cmd, cmd2, cmd3, cmd4;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string query = "Select aPassword from Account where username= '" + un + "' and aType='trainer'";
            cmd = new SqlCommand(query, conn);
            object password = cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (password.ToString() == null || password.ToString() != pass)
            {
                MessageBox.Show("Invalid password");
            }
            else
            {
                string query2 = "Select accountID from Account where username= '" + un + "' and aType='trainer' and apassword='" + pass + "'";
                cmd2 = new SqlCommand(query2, conn);
                object accountid = cmd2.ExecuteScalar();
                int accountId = Convert.ToInt32(accountid);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                string query3 = "Select trainerID from Trainer WHERE accountID = " + accountId;
                cmd3 = new SqlCommand(query3, conn);
                object trainerid = cmd3.ExecuteScalar();
                trainerID = Convert.ToInt32(trainerid);
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();

                conn.Close();
                this.Hide();
                //trainer form = new trainer(trainerID,gymID);
                trainer form = new trainer(trainerID);
                form.Show();
                form.FormClosed += (s, argc) => this.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signupTrainer form = new signupTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void loginTrainer_Load(object sender, EventArgs e)
        {

        }

    }
}
