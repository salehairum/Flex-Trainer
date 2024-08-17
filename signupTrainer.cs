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
using System.Configuration;

namespace project
{
    public partial class signupTrainer : Form
    {
        int trainerID;
        public signupTrainer()
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
            string exp = textBox6.Text;
            exp += " years";
            string query1 = "insert into Account values('trainer','" + password + "','" + uname + "','" + email + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            string query2 = "select accountID from account where username='" + uname + "'";
            cm3 = new SqlCommand(query2, conn);
            object aID = cm3.ExecuteScalar();
            int accID = Convert.ToInt32(aID);
            string query3 = "insert into Trainer values('" + name + "'," + "convert(date,'" + dob + "'),'" + exp + "'," + accID + ")";
            cm2 = new SqlCommand(query3, conn);
            cm2.ExecuteNonQuery();
            cm2.Dispose();
            string query4 = "select trainerID from trainer where accountID=" + accID;
            cm4 = new SqlCommand(query4, conn);
            object adID = cm3.ExecuteScalar();
            trainerID = Convert.ToInt32(aID);
            cm4.Dispose();
            conn.Close();
            this.Hide();
            trainer form = new trainer(trainerID);
            //trainer form = new trainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
