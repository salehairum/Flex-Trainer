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
using System.Configuration;

namespace project
{
    public partial class signupGymowner : Form
    {
        int accountIDofGymOwner;
        int gymOwnerIDofGymOwner;
        public signupGymowner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;SqlConnection conn = new SqlConnection(conString);

            conn.Open();
            SqlCommand cm, cm2, cm3, cm4;
            string uname = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            string name = textBox4.Text;
            string dob = textBox5.Text;
            string query1 = "insert into Account values('gymowner','" + password + "','" + uname + "','" + email + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            string query2 = "select accountID from account where username='" + uname + "' and atype='gymowner'";
            cm3 = new SqlCommand(query2, conn);
            object aID = cm3.ExecuteScalar();
            accountIDofGymOwner = Convert.ToInt32(aID);
            cm3.Dispose();
            string query3 = "INSERT INTO GymOwner (gName, dob, accountId) VALUES ('" + uname + "','" + dob + "'," + accountIDofGymOwner + ")";
            cm2 = new SqlCommand(query3, conn);
            cm2.ExecuteNonQuery();
            cm2.Dispose();
            string query4 = "select gymOwnerId from GymOwner where username='" + uname + "' and accountId='" + accountIDofGymOwner + ")";
            cm4 = new SqlCommand(query4, conn);
            object goId = cm4.ExecuteScalar();
            gymOwnerIDofGymOwner = Convert.ToInt32(goId);
            cm4.Dispose();
            conn.Close();
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerIDofGymOwner);
            //gymowner_cs form = new gymowner_cs(accountIDofGymOwner);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void signupGymowner_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
