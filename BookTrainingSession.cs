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
    public partial class BookTrainingSession : Form
    {
        private int userId;
        int trainerId;
        string time;

        public BookTrainingSession(int userId)
        {
            InitializeComponent();
            LoadComboBoxDataWithTrainerID();
            this.userId = userId;
        }
        public BookTrainingSession()
        {
            InitializeComponent();
            this.userId = 52;
            LoadComboBoxDataWithTrainerID();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadComboBoxDataWithTrainerID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT trainerId FROM trainer";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items in the ComboBox
                    comboBox1.Items.Clear();

                    // Add items manually
                    while (reader.Read())
                    {
                        int dpID = reader.GetInt32(0);
                        comboBox1.Items.Add(dpID);
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

        private void Approve1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            SqlCommand cmd;
            string query = "insert into BookPersonalTrainingSession (trainerId, memberId, timee) values(" + trainerId + "," + userId + ",convert(time, '" + time + "'))";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void BookTrainingSession_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            time = textBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                trainerId = Convert.ToInt32(comboBox1.SelectedItem);
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

        private void givefeedback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
