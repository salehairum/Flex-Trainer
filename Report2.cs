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
    public partial class Report2 : Form
    {
        int gymID;
        int dietPlanID;
        public Report2()
        {
            InitializeComponent();
            LoadComboBoxDataWithGymID();
            LoadComboBoxDataWithDietPlanID();
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select member.memberID, mName, dob, status, accountID, gymID from member inner join MemberUsesDietPlan on member.memberID = MemberUsesDietPlan.memberId where gymID = "+gymID+ " AND dietPlanId = " + dietPlanID , sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gymID = Convert.ToInt32(comboBox1.SelectedItem);
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
                        int gymId= reader.GetInt32(0); // Assuming gymID is in the first column
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
        private void LoadComboBoxDataWithDietPlanID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT dietplanId FROM memberUsesDietPlan";
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
                        int dpID = reader.GetInt32(0);
                        comboBox2.Items.Add(dpID);
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
            dietPlanID = Convert.ToInt32(comboBox2.SelectedItem);
        }

        private void Report2_Load(object sender, EventArgs e)
        {

        }
    }
}
