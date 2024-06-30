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
    public partial class FeedbackTrainer : Form
    {
        int memberID;
        int userID;
        string memberName;
        string rating;
        string help;
        string response;
        string dicipline;
        string comment;
        public FeedbackTrainer()
        {
            InitializeComponent();
            userID = 1;
            LoadComboBoxDataWithMember();
        }
        public FeedbackTrainer(int trainerID)
        {
            InitializeComponent();
            userID = trainerID;
            LoadComboBoxDataWithMember();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxDataWithMember()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT member.memberID,member.mName FROM FeedbackTrainer inner join Member on FeedbackTrainer.memberID=member.memberID where FeedbackTrainer.trainerID=" + userID;
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
                        // Assuming mealID is in the first column (index 0), and mealName is in the second column (index 1)
                        int mID = reader.GetInt32(0);
                        string mName = reader.GetString(1);
                        // You can combine mealID and mealName into a single string or use them separately as per your requirement
                        string item = mID.ToString() + " " + mName;
                        comboBox1.Items.Add(item);
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(userID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(userID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Workout_Plan form = new Trainer_Workout_Plan();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplanTrainer form = new dietplanTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainingSessionRequest form = new TrainingSessionRequest(userID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Split the selected value by ':' and retrieve the first part (mealID)
                string selectedValue = comboBox1.SelectedItem.ToString();
                string temp = "";
                for (int i = 0; selectedValue[i] != ' '; i++)
                {
                    temp += selectedValue[i];
                }
                memberID = Convert.ToInt32(temp);
            }
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query = "SELECT member.memberID,member.mName,FeedbackTrainer.rating,FeedbackTrainer.help,FeedbackTrainer.discipline,FeedbackTrainer.comment FROM FeedbackTrainer inner join Member on FeedbackTrainer.memberID=member.memberID where FeedbackTrainer.trainerID=" + userID + " and Member.memberID=" + memberID;
            SqlCommand cmd = new SqlCommand(query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Extract data from the reader
                    memberName = reader.GetString(1); // Assuming mName is the second column
                    rating = reader.GetInt32(2).ToString(); // Assuming rating is the third column
                    help = reader.GetInt32(3).ToString();
                    ///response= reader.GetString(4).ToString();
                    dicipline = reader.GetInt32(4).ToString();
                    comment = reader.GetString(5);
                    label3.Text = memberName;
                    label9.Text = rating;
                    label6.Text = help;
                    //label5.Text = response;
                    label7.Text = dicipline;
                    label4.Text = comment;
                }
                else
                {
                    Console.WriteLine("No data found for the specified criteria.");
                }
            }

            conn.Close();

        }
    }
}
