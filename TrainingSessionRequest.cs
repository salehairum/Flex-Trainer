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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class TrainingSessionRequest : Form
    {
        int trainerID;
        int memberID;
        string mName;
        string timee;
        string newTimee;
        public TrainingSessionRequest(int trainerID)
        {
            InitializeComponent();
            this.trainerID= trainerID;
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        /*
        private void TrainingSessionRequest_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string dob;
            SqlCommand cm1, cm2, cm3;
            //extracting memberId
            string query1 = "SELECT memberId FROM BookPersonalTrainingSession WHERE trainerID ='" + this.trainerID + "'";
            cm1 = new SqlCommand(query1, conn);
            object result = cm1.ExecuteScalar();
            this.memberID=Convert.ToInt32(result);
            cm1.Dispose();
            //extracting name
            string query2 = "SELECT mName FROM Member WHERE memberID ='" + this.memberID + "'";
            cm2 = new SqlCommand(query2, conn);
            object result2 = cm2.ExecuteScalar();
            mName = result2.ToString();
            cm2.Dispose();
            //extracting time
            string query3 = "SELECT timee FROM BookPersonalTrainingSession WHERE trainerId ='" + this.trainerID + "'";
            cm3 = new SqlCommand(query3, conn);
            object result3 = cm3.ExecuteScalar();
            timee = result3.ToString();
            cm3.Dispose();
            label1.Text += ": " + memberID;
            label5.Text += ": " + mName;
            label10.Text += ": " + timee;
            conn.Close();
        }

        private void TrainingSessionRequest_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "SELECT memberId, timee FROM BookPersonalTrainingSession WHERE trainerID = @trainerID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@trainerID", trainerID);

            SqlDataReader reader = cmd.ExecuteReader(); // Execute the query and get a reader

            while (reader.Read()) // Loop through each record
            {
                int memberId = reader.GetInt32(0);
                TimeSpan time1 = reader.GetTimeSpan(1);
                string timee = time1.ToString();

                // Create labels dynamically
                Label memberIdLabel = new Label();
                memberIdLabel.Text = "Member ID:";
                memberIdLabel.Location = new Point(10, 10); // Set position (adjust as needed)
                memberIdLabel.AutoSize = true; // Automatically adjust size based on text

                Label timeLabel = new Label();
                timeLabel.Text = "Time:";
                timeLabel.Location = new Point(10, 40); // Set position (adjust as needed)
                timeLabel.AutoSize = true;

                // Display data in dynamically created labels
                memberIdLabel.Text += " " + memberId;
                timeLabel.Text += " " + timee;

                // Add labels to the form
                this.Controls.Add(memberIdLabel);
                this.Controls.Add(timeLabel);
            }

            reader.Close();
            conn.Close();
        }

        */

        private int currentRecordIndex = 0;
        int totalRecords = 0; // Stores the total number of records

        private void TrainingSessionRequest_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "SELECT memberId, timee FROM BookPersonalTrainingSession WHERE trainerID = @trainerID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@trainerID", trainerID);

            SqlDataReader reader = cmd.ExecuteReader(); // Execute the query and get a reader

            // Loop through each record and count them
            while (reader.Read())
            {
                memberID = reader.GetInt32(0);
                //string mName = reader.GetString(1);
                timee = reader.GetTimeSpan(1).ToString(); // Assuming timee is the third column

                // You can update your form labels here or store the data for later display

                totalRecords++; // Increment counter for each record
            }

            reader.Close();

            // Assuming there are records, display the first one
            if (totalRecords > 0)
            {
                string query1 = "SELECT memberId, timee FROM BookPersonalTrainingSession WHERE trainerID = @trainerID";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@trainerID", trainerID);

                reader = cmd1.ExecuteReader();
                reader.Read(); // Move to the first record

                this.memberID = reader.GetInt32(0);
                //string mName = reader.GetString(1);
                this.timee = reader.GetTimeSpan(1).ToString(); // Assuming timee is the third column

                // Update your form labels or display the data
                label2.Text = "Member Id: " + memberID;
                //label5.Text = ": " + mName;
                label11.Text = "Time: " + timee;

                currentRecordIndex++;
            }

            reader.Close();
            conn.Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(trainerID);
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

        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackTrainer form = new FeedbackTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reschedule1_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;

        }

        private void newTime_TextChanged(object sender, EventArgs e)
        {
            if (newTime.Text != null)
            {
                this.newTimee = newTime.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query1 = "UPDATE BookPersonalTrainingSession SET timee = @newTimee WHERE memberId = @memberId and trainerId = @trainerId";

            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@newTimee", newTimee); // Replace with actual new time value
                cmd.Parameters.AddWithValue("@memberId", memberID);
                cmd.Parameters.AddWithValue("@trainerId", trainerID);
                cmd.ExecuteNonQuery();
            }
            panel12.Visible = false;
            label11.Text = "Time: " + newTimee;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "SELECT memberId, timee FROM BookPersonalTrainingSession WHERE trainerID = @trainerID and approved = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@trainerID", trainerID);

            SqlDataReader reader = cmd.ExecuteReader(); // Execute the query again

            // Check if there are more records to display
            if (reader.HasRows && currentRecordIndex < totalRecords) // Assuming you have totalRecords variable
            {
                reader.Read(); // Move to the next record (based on currentRecordIndex)

                this.memberID = reader.GetInt32(0);
                // string mName = reader.GetString(1);
                this.timee = reader.GetTimeSpan(1).ToString(); // Assuming timee is the third column

                // Update your form labels or display the data
                label2.Text = "Member Id: " + memberID;
                // label5.Text = ": " + mName;
                label11.Text = "Time: " + timee;

                currentRecordIndex++;
            }
            else
            {
                MessageBox.Show("No more records.");
            }

            reader.Close();
            conn.Close();
        }

        private void Reschedule2_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
        }

        private void Approve2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query1 = "UPDATE BookPersonalTrainingSession SET approved = 1 WHERE memberId = @memberId and trainerId = @trainerId";

            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@memberId", memberID);
                cmd.Parameters.AddWithValue("@trainerId", trainerID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Approved");
        }

        private void Reject2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query1 = "delete from BookPersonalTrainingSession WHERE memberId = @memberId and trainerId = @trainerId";

            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@memberId", memberID);
                cmd.Parameters.AddWithValue("@trainerId", trainerID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Rejected");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            trainer form = new trainer(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
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
