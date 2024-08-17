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
    public partial class admin : Form
    {
        int adminID;
        string uname;
        string dob;
        public admin(int adminID)
        {
            InitializeComponent();
            this.adminID = adminID;
        }

        private void admin_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            string dob;
            SqlCommand cm1, cm2;
            string query1 = "SELECT aName FROM Admin WHERE adminID ='" + this.adminID + "'";
            cm1 = new SqlCommand(query1, conn);
            object result = cm1.ExecuteScalar();
            uname = result.ToString();
            cm1.Dispose();
            string query2 = "SELECT dob FROM Admin WHERE adminID ='" + this.adminID + "'";
            cm2 = new SqlCommand(query2, conn);
            object result2 = cm2.ExecuteScalar();
            dob = result2.ToString();
            cm2.Dispose();
            label20.Text += ": " + uname;
            label19.Text += ": " + dob;
            conn.Close();
        }

        private void approve_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            removeGym form = new removeGym(adminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            GymReport form = new GymReport(adminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerGymAdmin form = new registerGymAdmin(adminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewForms form = new viewForms(adminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
