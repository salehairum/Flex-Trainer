using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class AddTrainer : Form
    {
        int gymOwnerID;
        int gymID;
        string exp;
        string qual;
        string spec;
        int trainerId;
        public AddTrainer(int gymOwnerID)
        {
            InitializeComponent();
            this.gymOwnerID = gymOwnerID;
        }

        private void AddTrainer_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "SELECT gymId FROM Gym where gymOwnerId=@gymownerid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@gymownerid", gymOwnerID);
            object id = cmd.ExecuteScalar();
            this.gymID = Convert.ToInt32(id);

            string query1 = "SELECT trainerId FROM TrainerJoinsGym where gymId=@id and approved = 0";
            SqlCommand cmd2 = new SqlCommand(query1, conn);
            cmd2.Parameters.AddWithValue("@id", gymID);
            object tid = cmd2.ExecuteScalar();
            trainerId = Convert.ToInt32(tid);

            string queryCombined = @"
SELECT 
    T.experience, 
    TQ.qName AS qualification, 
    TS.sName AS specialty 
FROM Trainer T
LEFT JOIN TrainerQualifications TQ ON T.trainerID = TQ.trainerID
LEFT JOIN TrainerSpecialty TS ON T.trainerID = TS.trainerID
WHERE T.trainerID = @id"; // Assuming trainerID is defined

            SqlCommand cmdCombined = new SqlCommand(queryCombined, conn);
            cmdCombined.Parameters.AddWithValue("@id", trainerId);

            SqlDataReader readerCombined = cmdCombined.ExecuteReader(); // Execute and get reader

            if (readerCombined.HasRows) // Check if there are any records
            {
                readerCombined.Read();
                exp = readerCombined.GetString(0); // Assuming experience is the first column
                qual = readerCombined.GetString(1); // Assuming qName is the second column
                spec = readerCombined.GetString(2); // Assuming sName is the third column
                readerCombined.Close(); // Close the reader

                // Update your form labels or display the data
                label3.Text = qual;
                label4.Text = exp;
                label6.Text = spec;
                // Use experience, qualification, and specialty for display or further processing
            }

            else
            {
                    MessageBox.Show("No Trainer Registration Requests yet!");
                    this.Hide();
                    gymowner_cs form = new gymowner_cs(gymOwnerID);
                    form.Show();
                    form.FormClosed += (s, argc) => this.Close();
            }
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void done_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "update TrainerJoinsGym set approved = 1 where trainerId= @trainerId and gymId=@gymId";
            SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@trainerId", trainerId);
            cmd2.Parameters.AddWithValue("@gymId", gymID);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Trainer Added");

            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            
            string query = "delete from TrainerJoinsGym where trainerId= @trainerId and gymId=@gymId";
            SqlCommand cmd2 = new SqlCommand(query, conn);
            cmd2.Parameters.AddWithValue("@trainerId", trainerId);
            cmd2.Parameters.AddWithValue("@gymId", gymID);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Request Rejected");
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
