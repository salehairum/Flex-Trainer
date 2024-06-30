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
    public partial class Report1 : Form
    {
        int gymID;
        int trainerID;
        public Report1()
        {
            InitializeComponent();
            LoadComboBoxDataWithGymID();
            LoadComboBoxDataWithTrainerID();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Report1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gymID = Convert.ToInt32(comboBox1.SelectedItem);
        }


        private void LoadComboBoxDataWithTrainerID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT trainerID FROM trainer";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items in the ComboBox
                    comboBox2.Items.Clear();

                    // Add items manually
                    while (reader.Read())
                    {
                        int trainerId = reader.GetInt32(0); // Assuming gymID is in the first column
                        comboBox2.Items.Add(trainerId);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            trainerID = Convert.ToInt32(comboBox2.SelectedItem);
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select member.memberID, mName, dob, gymid, trainerID from member inner join BookPersonalTrainingSession on member.memberID=BookPersonalTrainingSession.memberId where gymid=" + gymID+" AND trainerid="+trainerID, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
