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
    public partial class Report6 : Form
    {
        int AdminID;
        public Report6(int userId)
        {
            AdminID = userId;
            InitializeComponent();
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select dietplanid, sum(meals.carbohydrates) as amount_of_carbs from MealInDietPlanMember inner join meals on meals.mealId = MealInDietPlanMember.mealID group by dietPlanId having sum(meals.carbohydrates) < 300 union all select dietplanid, sum(meals.carbohydrates) as amount_of_carbs from MealInDietPlanTrainer inner join meals on meals.mealId = MealInDietPlanTrainer.mealID group by dietPlanId having sum(meals.carbohydrates) < 300", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void name_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void givefeedback_Click(object sender, EventArgs e)
        {

        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewForms form = new viewForms(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
