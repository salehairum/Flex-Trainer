using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace project
{
    public partial class LoginMember : Form
    {
        int memberID;
        int gymID;
        public LoginMember()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SignupMember form = new SignupMember();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            SqlCommand cmd, cmd2, cmd3, cmd4;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string query = "Select aPassword from Account where username= '" + un + "' and aType='member'";
            cmd = new SqlCommand(query, conn);
            object password = cmd.ExecuteScalar();
            cmd.Dispose();
            if (password!=null && (password.ToString() == null || password.ToString() != pass))
            {
                MessageBox.Show("Invalid password");
            }
            else
            {
                string query2 = "Select accountID from Account where username= '" + un + "' and aType='member' and apassword='" + pass + "'";
                cmd2 = new SqlCommand(query2, conn);
                object accountid = cmd2.ExecuteScalar();
                int accountId = Convert.ToInt32(accountid);
                cmd2.Dispose();

                string query3 = "Select memberID from member WHERE accountId = " + accountId;
                cmd3 = new SqlCommand(query3, conn);
                object memberid = cmd3.ExecuteScalar();
                memberID = Convert.ToInt32(memberid);
                cmd3.Dispose();

                string query4 = "Select gymID from member WHERE memberID = " + memberID;
                cmd4 = new SqlCommand(query4, conn);
                object gymid = cmd4.ExecuteScalar();
                gymID = Convert.ToInt32(gymid);
                cmd4.Dispose();

                conn.Close();
                this.Hide();
                member form = new member(memberID);
                //member form = new member(memberID,gymID);
                form.Show();
                form.FormClosed += (s, argc) => this.Close();
            }
        }
    }
}
