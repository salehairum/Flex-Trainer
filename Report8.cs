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
    public partial class Report8 : Form
    {
        int AdminID;
        public Report8(int userId)
        {
            AdminID = userId;
            InitializeComponent();
        }

        private void Report8_Load(object sender, EventArgs e)
        {

        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select DietPlanMember.dietplanId, purpose, dtype, portionSize, allergenName  from DietPlanMember inner join MealInDietPlanMember on DietPlanMember.dietPlanID = MealInDietPlanMember.dietPlanId inner join meals on MealInDietPlanMember.mealID = meals.mealID inner join Allergens on Allergens.mealID = meals.mealID where allergens.allergenName not in ('peanuts') union all select DietPlanTrainer.dietplanId, purpose, dType, portionSize, allergenName from DietPlanTrainer inner join MealInDietPlanTrainer on DietPlanTrainer.dietPlanID = MealInDietPlanTrainer.dietPlanId inner join meals on MealInDietPlanTrainer.mealID = meals.mealID inner join Allergens on Allergens.mealID = meals.mealID where allergens.allergenName not in ('peanuts')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
