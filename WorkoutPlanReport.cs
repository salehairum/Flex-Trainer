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
    public partial class WorkoutPlanReport : Form
    {
        int memberid;
        string madeBy;
        public WorkoutPlanReport()
        {
            InitializeComponent();
            memberid = 53;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //workout plans by members
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplanmember where memberid!="+memberid, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //workout plans by trainers
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        //filter by purpose
        {
            comboBox1.Visible = !comboBox1.Visible;
            LoadComboBoxDataWithPurposes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboBoxDataWithPurposes()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string selectedPurpose = selectedRow["purpose"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            //workout plans by trainers
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplantrainer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        //filter by experience
        {
            comboBox2.Visible = !comboBox2.Visible;
            LoadComboBoxDataWithExperience();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox2.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string experience = selectedRow["experienceRequired"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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

        private void label4_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = !comboBox3.Visible;
            LoadComboBoxDataWithMemberID();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox4.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox4.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int trainerID = Convert.ToInt32(selectedRow["trainerID"]);
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
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

        private void label5_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = !comboBox4.Visible;
            LoadComboBoxDataWithTrainerID();
        }

        private void GenerateGridView()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                int setss = Convert.ToInt32(textBox1.Text);
                int reps = Convert.ToInt32(textBox2.Text);
                int restIntervals = Convert.ToInt32(textBox3.Text);

                using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM workoutplanMember WHERE setss <= "+setss+" AND reps <= "+reps+ "AND restIntervals <= " + restIntervals + "UNION SELECT * FROM workoutplanTrainer WHERE  setss <= " + setss + " AND reps <= " + reps + "AND restIntervals <= " + restIntervals , sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
            textBox3.Visible = !textBox3.Visible;

            label6.Visible = !label6.Visible;
            label7.Visible = !label7.Visible;
            label9.Visible = !label9.Visible;

            Reject1.Visible = !Reject1.Visible;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Approve1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            SqlCommand cm;
            if (textBox4.Text != null)
            {
                int workoutPlanID = Convert.ToInt32(textBox4.Text);
                string query1;
                if (madeBy=="Trainer")
                    query1= "insert into memberusesWorkoutPlanTrainer values (" + workoutPlanID + ", " + memberid + ")";
                query1 = "insert into memberusesWorkoutPlan values (" + workoutPlanID + ", " + memberid + ")";
                cm = new SqlCommand(query1, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
            }
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            GenerateGridView();
        }

        private void WorkoutPlanReport_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void name_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void givefeedback_Click(object sender, EventArgs e)
        {

        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {

        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {

        }

        private void createdietplan_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from workoutplanmember where memberid="+memberid, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            comboBox5.Visible = !comboBox5.Visible;
            textBox4.Visible = !textBox4.Visible;
            label10.Visible = !label10.Visible;
            label12.Visible = !label12.Visible;
            Approve1.Visible = !Approve1.Visible;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            madeBy = comboBox5.SelectedItem.ToString();
        }
    }
}
