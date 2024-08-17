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
    public partial class AReport10 : Form
    {
        int AdminID;
        public AReport10(int userId)
        {
            InitializeComponent();
            AdminID = userId;
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select  trainerId, count(workoutplanid) as number_of_plans from WorkoutPlanTrainer group by trainerID", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            viewForms form = new viewForms(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
