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
    public partial class Report4 : Form
    {
        int gymID;
        string MachineName;
        string day;
        public Report4()
        {
            InitializeComponent();
            LoadComboBoxDataWithGymID();
            LoadComboBoxDataWithMachineName();
        }

        private void Report4_Load(object sender, EventArgs e)
        {

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
        private void LoadComboBoxDataWithMachineName()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT MachineName FROM WorkoutPlanMember inner join WorkoutPlanContainsExerciseMember on WorkoutPlanMember.workoutPlanID = WorkoutPlanContainsExerciseMember.workOutPlanId inner join exercise on exercise.exerciseID = WorkoutPlanContainsExerciseMember.exerciseID";
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
                        string mName = reader.GetString(0);
                        comboBox2.Items.Add(mName);
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
            if (comboBox2.SelectedItem != null)
            {
                MachineName = comboBox2.SelectedItem.ToString();
            }
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                string query = "select count(member.memberID) as numberOfMembers from member inner join MemberUsesWorkoutPlan on member.memberId = MemberUsesWorkoutPlan.memberId inner join WorkoutPlanContainsExerciseMember on MemberUsesWorkoutPlan.workOutPlanId = WorkoutPlanContainsExerciseMember.workOutPlanId inner join exercise on WorkoutPlanContainsExerciseMember.exerciseID = Exercise.exerciseID inner join WorkoutPlanMember on WorkoutPlanContainsExerciseMember.workOutPlanId = WorkoutPlanMember.workoutPlanID where exercise.machineName = '" + MachineName + "' AND gymId =" + gymID + " AND WorkoutPlanMember.dayy = '" + day + "'";
                SqlCommand cm = new SqlCommand(query, sqlCon);
                object count = cm.ExecuteScalar();
                int number = Convert.ToInt32(count);
                label6.Text = number.ToString();
                label6.Visible = !label6.Visible;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            day = comboBox3.SelectedItem.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                MachineName = comboBox2.SelectedItem.ToString();
            }
        }
    }
}
