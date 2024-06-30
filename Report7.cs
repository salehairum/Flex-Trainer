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
    public partial class Report7 : Form
    {
        string MachineName;
        public Report7()
        {
            InitializeComponent();
            LoadComboBoxDataWithMachineName();
        }

        private void Report7_Load(object sender, EventArgs e)
        {

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
                    comboBox1.Items.Clear();

                    // Add items manually
                    while (reader.Read())
                    {
                        string mName = reader.GetString(0);
                        comboBox1.Items.Add(mName);
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

            if (comboBox1.SelectedItem != null)
            {
                MachineName = comboBox1.SelectedItem.ToString();
            }
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select WorkoutPlanMember.workoutPlanID, memberID, muscleToWorkout, dayy, experienceRequired, setss, reps, restIntervals from WorkoutPlanMember inner join WorkoutPlanContainsExerciseMember on WorkoutPlanMember.workoutPlanID=WorkoutPlanContainsExerciseMember.workOutPlanId inner join exercise on exercise.exerciseID=WorkoutPlanContainsExerciseMember.exerciseID where exercise.machineName not in ('" + MachineName + "') union all select WorkoutPlanTrainer.workoutPlanID, TrainerID, muscleToWorkout, dayy, experienceRequired, setss, reps, restIntervals from WorkoutPlanTrainer inner join WorkoutPlanContainsExerciseTrainer on WorkoutPlanTrainer.workoutPlanID=WorkoutPlanContainsExerciseTrainer.workOutPlanId inner join exercise on exercise.exerciseID=WorkoutPlanContainsExerciseTrainer.exerciseID where exercise.machineName not in ('" + MachineName + "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
