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
    public partial class DietPlanReport : Form
    {
        int nutrition;
        int memberid;
        string madeBy;
        public DietPlanReport()
        {
            InitializeComponent();
            memberid = 53;
        }

        private void DietPlanReport_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string selectedPurpose = selectedRow["purpose"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplantrainer where purpose='" + selectedPurpose + "' union select *  from dietplanmember where purpose='" + selectedPurpose + "'", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void LoadComboBoxDataWithPurposes()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT DISTINCT purpose FROM dietplantrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "dietplantrainer");

                    // Bind the ComboBox
                    comboBox1.DisplayMember = "purpose";
                    comboBox1.DataSource = ds.Tables["dietplantrainer"];
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
            comboBox1.Visible = !comboBox1.Visible;
            LoadComboBoxDataWithPurposes();
        }
        private void LoadComboBoxDataWithType()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT DISTINCT dType FROM dietplantrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "dietplantrainer");

                    // Bind the ComboBox
                    comboBox2.DisplayMember = "dType";
                    comboBox2.DataSource = ds.Tables["dietplantrainer"];
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

        private void label2_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
            LoadComboBoxDataWithType();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox2.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string type = selectedRow["dtype"].ToString();
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplantrainer where dtype='" + type + "' union select *  from dietplanmember where dtype='" + type + "'", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem != null)
            {
                string portion = comboBox5.SelectedItem.ToString();
                using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplanmember where portionSize='"+portion+ "' union all Select * from dietplantrainer where portionSize='" + portion+"'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlData.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox3.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int memberID = Convert.ToInt32(selectedRow["memberID"]);
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplanmember where memberID=" + memberID, sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void LoadComboBoxDataWithMemberID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT distinct memberID FROM dietplanmember";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "dietplanmember");

                    // Bind the ComboBox
                    comboBox3.DisplayMember = "memberID";
                    comboBox3.DataSource = ds.Tables["dietplanmember"];
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
        private void LoadComboBoxDataWithTrainerID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT distinct TrainerID FROM dietplanTrainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "dietplanTrainer");

                    // Bind the ComboBox
                    comboBox4.DisplayMember = "TrainerID";
                    comboBox4.DataSource = ds.Tables["dietplanTrainer"];
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
        private void displayNutritionGrid()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                conn.Open();
                string query1 = "create view Nutritional_Values_Of_Member_DietPlans as select dietplanid, meals.mealName, sum(meals.carbohydrates + meals.fat + meals.fiber + meals.protein) as nutritional_value from MealInDietPlanMember inner join meals on meals.mealId = MealInDietPlanMember.mealID group by dietPlanId, meals.mealName";
                string query2 = "create view Nutritional_Values_Of_Trainer_DietPlans as select dietplanid, meals.mealName, sum(meals.carbohydrates + meals.fat + meals.fiber + meals.protein) as nutritional_value from MealInDietPlanTrainer inner join meals on meals.mealId = MealInDietPlanTrainer.mealID group by dietPlanId, meals.mealName";
                SqlCommand cm = new SqlCommand(query1, conn);
                SqlCommand cm2 = new SqlCommand(query2, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
                cm2.ExecuteNonQuery();
                cm2.Dispose();

                SqlDataAdapter sqlData = new SqlDataAdapter("select * from Nutritional_Values_Of_Member_DietPlans where nutritional_value >"+nutrition+ "  union all select * from Nutritional_Values_Of_Trainer_DietPlans where nutritional_value >" + nutrition, conn);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                string query3 = "drop view Nutritional_Values_Of_Member_DietPlans";
                string query4 = "drop view Nutritional_Values_Of_Trainer_DietPlans";
                SqlCommand cm3 = new SqlCommand(query3, conn);
                SqlCommand cm4 = new SqlCommand(query4, conn);
                cm3.ExecuteNonQuery();
                cm3.Dispose();
                cm4.ExecuteNonQuery();
                cm4.Dispose();
                conn.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = !comboBox3.Visible;
            LoadComboBoxDataWithMemberID();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox4.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int trainerID = Convert.ToInt32(selectedRow["trainerID"]);
                    using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplantrainer where trainerID=" + trainerID, sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlData.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = !comboBox4.Visible;
            LoadComboBoxDataWithTrainerID();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            comboBox6.Visible = !comboBox6.Visible;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            nutrition = Convert.ToInt32(comboBox6.SelectedValue);
            displayNutritionGrid();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            comboBox5.Visible = !comboBox5.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplanmember where memberid!=" + memberid, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplantrainer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            comboBox7.Visible = !comboBox7.Visible;
            label10.Visible = !label10.Visible;
            label8.Visible = !label8.Visible;
            textBox4.Visible = !textBox4.Visible;
            Approve1.Visible = !Approve1.Visible;
        }

        private void Approve1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            if (textBox4.Text != null)
            {
                int DietPlanID = Convert.ToInt32(textBox4.Text);
                string query1;
                if (madeBy == "Trainer")
                    query1 = "insert into memberusesDietPlanTrainer values (" + DietPlanID + ", " + memberid + ")";
                query1 = "insert into memberusesDietPlan values (" + DietPlanID + ", " + memberid + ")";
                cm = new SqlCommand(query1, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            madeBy = comboBox7.SelectedItem.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from dietplanmember where memberid=" + memberid, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
