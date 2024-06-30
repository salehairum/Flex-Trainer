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
    public partial class Trainer_Workout_Plan : Form
    {
        int trainerID;
        public Trainer_Workout_Plan()
        {
            InitializeComponent();
            trainerID = 3;
        }
        public Trainer_Workout_Plan(int userID)
        {
            trainerID = userID;
            InitializeComponent();
        }

        private void Trainer_Workout_Plan_Load(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackTrainer form = new FeedbackTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainingSessionRequest form = new TrainingSessionRequest(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {

        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {

        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplanTrainer form = new dietplanTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void Approve1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            SqlCommand cm;
            string day = maskedTextBox1.Text;
            string purpose = comboBox2.Text;
            int reps = Convert.ToInt32(maskedTextBox2.Text);
            int sets = Convert.ToInt32(maskedTextBox4.Text);
            string muscle = comboBox1.Text;
            int restInterval = Convert.ToInt32(maskedTextBox3.Text);
            string level = comboBox3.Text;
            string query = "Insert into WorkoutPlanTrainer values ('" + muscle + "','" + day + "'," + sets + "," + reps + "," + restInterval + ",'" + level + "'," + purpose + ",'" + trainerID + "')";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
        }

        private void Home_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            dietplanTrainer form = new dietplanTrainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TrainingSessionRequest form = new TrainingSessionRequest(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackTrainer form = new FeedbackTrainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
