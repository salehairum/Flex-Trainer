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
    public partial class memberWorkOutPlan : Form
    {
        int memberID;
        public memberWorkOutPlan(int userId)
        {
            InitializeComponent();
            this.memberID = userId;
        }
        public memberWorkOutPlan()
        {
            InitializeComponent();
            memberID = 52;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Reject1_Click(object sender, EventArgs e)
        {
            Hide();
            using (member form = new member(memberID))
                form.ShowDialog();
            Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            member form = new member(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DietPlanReport form = new DietPlanReport(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void workoutplanreport_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            WorkoutPlanReport form = new WorkoutPlanReport(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            dietplan form = new dietplan(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            BookTrainingSession form = new BookTrainingSession(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void Approve1_Click(object sender, EventArgs e)
        {
     
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString; SqlConnection conn = new SqlConnection(conString); conn.Open();
            SqlCommand cm;
            string day = maskedTextBox1.Text;
            string purpose = comboBox2.Text;
            int reps = Convert.ToInt32( maskedTextBox2.Text);
            int sets = Convert.ToInt32(maskedTextBox4.Text);
            string muscle = comboBox1.Text;
            int restInterval = Convert.ToInt32(maskedTextBox3.Text);
            string level = comboBox3.Text;
            string query = "Insert into WorkoutPlanMember values ('" + muscle + "','" + day + "'," + sets + "," + reps + "," + restInterval + ",'" + level + "'," + memberID + ",'"+purpose+ "')";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
