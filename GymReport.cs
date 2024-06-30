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
    public partial class GymReport : Form
    {
        public GymReport()
        {
            InitializeComponent(); 
            LoadComboBoxDataWithGymID();
        }
        private void label1_Click(object sender, EventArgs e)
        {
          //  comboBox1.Visible = !comboBox1.Visible;
        }
        private void LoadComboBoxDataWithGymID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT gymID FROM gym";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items in the ComboBox
                    comboBox4.Items.Clear();

                    // Add items manually
                    while (reader.Read())
                    {
                        int gymId = reader.GetInt32(0); // Assuming gymID is in the first column
                        comboBox4.Items.Add(gymId);
                    }
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
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT gymid, count(memberId) as number_of_members FROM member group by gymid", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT gymid, count(trainerID) as number_of_trainers FROM TrainerJoinsGym group by gymid", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void GymReport_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = !comboBox4.Visible;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                int gymID = Convert.ToInt32(comboBox4.SelectedItem);
                using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("Select * from gym where gymID=" + gymID, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            comboBox5.Visible = !comboBox5.Visible;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem != null)
            {
                int budget = Convert.ToInt32( comboBox5.SelectedItem);
                using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("Select * from gym where budget<" + budget, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string plan = comboBox2.SelectedItem.ToString();
                using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("Select * from gym where businessPlan='" + plan + "'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int rating = Convert.ToInt32(comboBox1.SelectedItem);
                using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("select gymid, avg(FeedbackTrainer.rating) from FeedbackTrainer inner join Trainer on Trainer.trainerID=FeedbackTrainer.trainerID inner join trainerJoinsGym on Trainer.trainerID=trainerJoinsGym.trainerId group by gymid having avg(FeedbackTrainer.rating)<="+rating, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
        }
    }
}
