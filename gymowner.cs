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
    public partial class gymowner_cs : Form
    {
        int gymOwnerID;
        string uname;
        string dob;
        public gymowner_cs(int gymOwnerID)
        {
            InitializeComponent();
            this.gymOwnerID = gymOwnerID;
        }

        private void gymowner_cs_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            string dob;
            SqlCommand cm1, cm2;
            string query1 = "SELECT gname FROM GymOwner WHERE gymOwnerId ='" + this.gymOwnerID + "'";
            cm1 = new SqlCommand(query1, conn);
            object result = cm1.ExecuteScalar();
            uname = result.ToString();
            cm1.Dispose();
            string query2 = "SELECT dob FROM GymOwner WHERE gymOwnerId ='" + this.gymOwnerID + "'";
            cm2 = new SqlCommand(query2, conn);
            object result2 = cm2.ExecuteScalar();
            dob = result2.ToString();
            cm2.Dispose();
            label20.Text += ": " + uname;
            label19.Text += ": " + dob;
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }


        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveTrainer form = new RemoveTrainer(this.gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveMember form = new RemoveMember(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainer form = new AddTrainer(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerGym form = new registerGym(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            //Hide();
            //using (report form = new report())
            //    form.ShowDialog();
            //Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }
        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            //member report
            //Hide();
            //using (report form = new report())
            //    form.ShowDialog();
            //Show();
        }
    }
}
