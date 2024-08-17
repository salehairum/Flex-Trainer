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
    public partial class member : Form
    {
        private int userId;
        string uname;
        string dob;
        string type;
        string duration;

        public member(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void member_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string dob;
            SqlCommand cm1, cm2, cm3, cm4;
            string query1 = "SELECT mName FROM Member WHERE memberID ='" + this.userId + "'";
            cm1 = new SqlCommand(query1, conn);
            object result = cm1.ExecuteScalar();
            uname = result.ToString();
            cm1.Dispose();
            string query2 = "SELECT dob FROM Member WHERE memberID='" + this.userId + "'";
            cm2 = new SqlCommand(query2, conn);
            object result2 = cm2.ExecuteScalar();
            dob = result2.ToString();
            cm2.Dispose();

            //type
            string query3 = "SELECT mType FROM Membership WHERE memberID='" + this.userId + "'";
            cm3 = new SqlCommand(query3, conn);
            object result3 = cm3.ExecuteScalar();
            type = result3.ToString();
            cm3.Dispose();

            //duration
            string query4 = "SELECT duration FROM Membership WHERE memberID='" + this.userId + "'";
            cm4 = new SqlCommand(query4, conn);
            object result4 = cm4.ExecuteScalar();
            duration = result4.ToString();
            cm4.Dispose();

            label20.Text += ": " + uname;
            label19.Text += ": " + dob;
            label16.Text += ": " + duration;
            label17.Text += ": " + type;

            conn.Close();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Hide();
            using (memberWorkOutPlan form = new memberWorkOutPlan())
                form.ShowDialog();
            Show();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }


        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrainingSession form = new BookTrainingSession(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkoutPlanReport form = new WorkoutPlanReport(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplan form = new dietplan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            DietPlanReport form = new DietPlanReport(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
