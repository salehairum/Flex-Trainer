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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class FeedbackMember : Form
    {
        private int userId;
        public int rating;
        public int help;
        public int dicipline;
        public string comment;
        public int trainerId;

        public FeedbackMember(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadComboBoxDataWithTrainerID(); // Call the method to
                                             // ComboBox data
        }
        public FeedbackMember()
        {
            InitializeComponent();
            userId = 52;
            LoadComboBoxDataWithTrainerID(); // Call the method to load ComboBox data
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void FeedbackMember_Load(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            member form = new member(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(userId);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrainingSession form = new BookTrainingSession(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void LoadComboBoxDataWithTrainerID()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string query = "SELECT trainerID FROM trainer";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "trainer");

                    // Bind the ComboBox
                    comboBox1.ValueMember = "trainerID";
                    comboBox1.DisplayMember = "trainerID";   //attribute
                    comboBox1.DataSource = ds.Tables["trainer"];   //table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            rating = 5;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            dicipline = 1;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            help = 5;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            comment = richTextBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton29_CheckedChanged_1(object sender, EventArgs e)
        {
            rating = 4;
        }

        private void radioButton28_CheckedChanged_1(object sender, EventArgs e)
        {
            rating = 3;
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            rating = 2;
        }



        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            help = 4;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            help = 3;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            help = 2;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            help = 1;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            dicipline = 5;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            dicipline = 4;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            dicipline = 3;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            dicipline = 2;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            SqlCommand cmd;
            string query = "insert into feedbackTrainer values('" + comment + "'," + rating + "," + dicipline + "," + help + "," + trainerId + "," + userId + ")";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }


        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            comment = richTextBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    trainerId= Convert.ToInt32(selectedRow["trainerID"]);
                }
            }
        }

        private void Home_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            member form = new member(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            dietplan form = new dietplan(userId);
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

        private void radioButton30_CheckedChanged_1(object sender, EventArgs e)
        {
            rating = 5;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void radioButton29_CheckedChanged_2(object sender, EventArgs e)
        {
            rating = 4;
        }

        private void radioButton28_CheckedChanged_2(object sender, EventArgs e)
        {
            rating = 3;
        }

        private void radioButton27_CheckedChanged_1(object sender, EventArgs e)
        {
            rating = 2;
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            rating = 1;
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            help = 1;
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkoutPlanReport form = new WorkoutPlanReport(userId);
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
    }
}