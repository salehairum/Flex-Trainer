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
    public partial class Report5 : Form
    {
        public Report5()
        {
            InitializeComponent();
        }

        private void Report5_Load(object sender, EventArgs e)
        {

        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open(); 
                string query = "create view Nutritional_Values_Of_Member_DietPlans as select dietplanid, meals.mealName, sum(meals.carbohydrates + meals.fat + meals.fiber + meals.protein) as nutritional_value from MealInDietPlanMember inner join meals on meals.mealId = MealInDietPlanMember.mealID group by dietPlanId, meals.mealName";
                string query2 = "create view Nutritional_Values_Of_Trainer_DietPlans as select dietplanid, meals.mealName, sum(meals.carbohydrates + meals.fat + meals.fiber + meals.protein) as nutritional_value from MealInDietPlanTrainer inner join meals on meals.mealId = MealInDietPlanTrainer.mealID group by dietPlanId, meals.mealName";
                SqlCommand cm = new SqlCommand(query, sqlCon);
                SqlCommand cm2 = new SqlCommand(query2, sqlCon);
                cm.ExecuteNonQuery();
                cm.Dispose();
                cm2.ExecuteNonQuery();
                cm2.Dispose();
                SqlDataAdapter sqlData = new SqlDataAdapter("select * from Nutritional_Values_Of_Member_DietPlans where nutritional_value < 500 AND mealName = 'Breakfast' union all select * from Nutritional_Values_Of_Trainer_DietPlans where nutritional_value < 500 AND mealName = 'Breakfast' ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                string query3 = "drop view Nutritional_Values_Of_Member_DietPlans";
                string query4 = "drop view Nutritional_Values_Of_Trainer_DietPlans";
                SqlCommand cm3 = new SqlCommand(query3, sqlCon);
                SqlCommand cm4 = new SqlCommand(query4, sqlCon);
                cm3.ExecuteNonQuery();
                cm3.Dispose();
                cm4.ExecuteNonQuery();
                cm4.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void name_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
