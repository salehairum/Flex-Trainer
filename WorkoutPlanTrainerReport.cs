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

namespace project
{
    public partial class WorkoutPlanTrainerReport : Form
    {
        int memberId;
        public WorkoutPlanTrainerReport(int userId)
        {
            InitializeComponent();
            memberId = userId;
        }

        private void LoadComboBoxDataWithPurposes()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT DISTINCT purpose FROM workoutplantrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "workoutplantrainer");

                    // Bind the ComboBox
                    comboBox1.DisplayMember = "purpose";
                    comboBox1.DataSource = ds.Tables["workoutplantrainer"];
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
        private void LoadComboBoxDataWithExperience()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT DISTINCT experienceRequired FROM workoutplantrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "workoutplantrainer");

                    // Bind the ComboBox
                    comboBox2.DisplayMember = "experienceRequired";
                    comboBox2.DataSource = ds.Tables["workoutplantrainer"];
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

        private void LoadComboBoxDataWithMemberID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT distinct memberID FROM workoutplanmember";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "workoutplanmember");

                    // Bind the ComboBox
                    comboBox3.DisplayMember = "memberID";
                    comboBox3.DataSource = ds.Tables["workoutplanmember"];
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
        private void LoadComboBoxDataWithTrainerID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT distinct TrainerID FROM workoutplanTrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "workoutplanTrainer");

                    // Bind the ComboBox
                    comboBox4.DisplayMember = "TrainerID";
                    comboBox4.DataSource = ds.Tables["workoutplanTrainer"];
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

        private void GenerateGridView()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                int setss = Convert.ToInt32(textBox1.Text);
                int reps = Convert.ToInt32(textBox2.Text);
                int restIntervals = Convert.ToInt32(textBox3.Text);

                using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM workoutplanMember WHERE setss <= " + setss + " AND reps <= " + reps + "AND restIntervals <= " + restIntervals + "UNION SELECT * FROM workoutplanTrainer WHERE  setss <= " + setss + " AND reps <= " + reps + "AND restIntervals <= " + restIntervals, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
            LoadComboBoxDataWithPurposes();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
            LoadComboBoxDataWithExperience();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = !comboBox3.Visible;
            LoadComboBoxDataWithMemberID();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = !comboBox4.Visible;
            LoadComboBoxDataWithTrainerID();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
            textBox3.Visible = !textBox3.Visible;

            label6.Visible = !label6.Visible;
            label7.Visible = !label7.Visible;
            label9.Visible = !label9.Visible;

            Reject1.Visible = !Reject1.Visible;
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            GenerateGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //workout plans by members
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplanmember", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from MemberUsesWorkoutPlan union all select * from MemberUsesWorkoutPlanTrainer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string selectedPurpose = selectedRow["purpose"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer where purpose='" + selectedPurpose + "' union select *  from workoutplanmember where purpose='" + selectedPurpose + "'", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void WorkoutPlanTrainerReport_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox2.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string experience = selectedRow["experienceRequired"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer where experienceRequired='" + experience + "' union select *  from workoutplanmember where experienceRequired='" + experience + "'", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox3.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int memberID = Convert.ToInt32(selectedRow["memberID"]);
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplanmember where memberID=" + memberID, sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox4.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int trainerID = Convert.ToInt32(selectedRow["trainerID"]);
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer where trainerID=" + trainerID, sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Workout_Plan form = new Trainer_Workout_Plan(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Workout_Plan form = new Trainer_Workout_Plan();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplanTrainer form = new dietplanTrainer(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            DietPlanTrainerReport form = new DietPlanTrainerReport(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainingSessionRequest form = new TrainingSessionRequest(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackTrainer form = new FeedbackTrainer(memberId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
