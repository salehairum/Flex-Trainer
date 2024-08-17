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
    public partial class FeedbackGym : Form
    {
        int gymID;
        int gymOwnerId;
        string rating;
        string help;
        string response;
        string dicipline;
        public FeedbackGym()
        {
            InitializeComponent();
            gymOwnerId = 30; 
            LoadComboBoxDataWithGymID();
        }
        private void LoadLabelsWithData()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                string query = "select avg(FeedbackTrainer.rating),avg(FeedbackTrainer.discipline),avg(FeedbackTrainer.help) from FeedbackTrainer inner join Trainer on Trainer.trainerID=FeedbackTrainer.trainerID inner join trainerJoinsGym on Trainer.trainerID=trainerJoinsGym.trainerId where trainerJoinsGym.gymId=" + gymID;
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rating = reader.GetInt32(0).ToString(); // Assuming rating is the third column
                        help = reader.GetInt32(2).ToString();
                        dicipline = reader.GetInt32(1).ToString();
                        label9.Text = rating;
                        label6.Text = help;
                        label7.Text = dicipline;
                    }
                    else
                    {
                        Console.WriteLine("No data found for the specified criteria.");
                    }
                }

                conn.Close();
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FeedbackGym_Load(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxDataWithGymID()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string query = "SELECT gymID FROM gym where gymownerid="+gymOwnerId;
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
                        int gymId = reader.GetInt32(0); // Assuming gymID is in the first column
                        comboBox1.Items.Add(gymId);
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
            gymID = Convert.ToInt32(comboBox1.SelectedItem);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            LoadLabelsWithData();
        }
    }
}
