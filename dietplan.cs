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
    public partial class dietplan : Form
    {
        string purpose;
        string dtype;
        string portionSize;
        private int userId;
        int mealID;
        string mealName;
        string mealAllergens;
        int protien;
        int carbs;
        int fats;
        int fib;
        int mealIDForAllergens;
        public dietplan(int userId)
        {
            InitializeComponent();
            LoadComboBoxDataWithMeal();
            this.userId = userId;
        }
        public dietplan()
        {
            InitializeComponent(); 
            LoadComboBoxDataWithMeal();
        }


        private void Approve1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            SqlCommand cm, cm2, cm3, cm4;
            int memberID = this.userId;
            string query = "Insert into dietPlanMember values ('" + purpose + "','" + dtype + "','" + portionSize + "','" + memberID + "')";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            int dietPlanID;
            string query4 = "select dietPlanID from dietPlanMember where purpose='" + purpose + "' and dtype= '" + dtype + "' and portionSize='" + portionSize + "' and memberID=" + userId;
            cm3 = new SqlCommand(query4, conn);
            object dietplanid = cm3.ExecuteScalar();
            dietPlanID = Convert.ToInt32(dietplanid);
            cm3.Dispose();
            string query2 = "Insert into MealInDietPlanMember values (" + dietPlanID + "," + mealID + ")";
            cm4 = new SqlCommand(query2, conn);
            cm4.ExecuteNonQuery();
            cm4.Dispose();
            conn.Close();


        }

        private void dietplan_Load(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            member form = new member(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTrainingSession form = new BookTrainingSession(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtype = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            purpose = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            portionSize = textBox4.Text;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Split the selected value by ':' and retrieve the first part (mealID)
                string selectedValue = comboBox1.SelectedItem.ToString();
                string temp = "";
                for (int i = 0; selectedValue[i] != ' '; i++)
                {
                    temp += selectedValue[i];
                }
                mealID = Convert.ToInt32(temp);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            mealName = textBox2.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            mealAllergens = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            protien = Convert.ToInt32(textBox6.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            carbs = Convert.ToInt32(textBox9.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            fib = Convert.ToInt32(textBox8.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            fats = Convert.ToInt32(textBox7.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            SqlCommand cm;
            int memberID = userId;
            string query = "INSERT INTO meals OUTPUT INSERTED.mealID values ('" + mealName + "'," + fats + "," + protien + "," + carbs + "," + fib + ")";
            cm = new SqlCommand(query, conn);
            mealIDForAllergens = Convert.ToInt32(cm.ExecuteScalar()); // Get the newly generated mealID
            cm.Dispose();
            SqlCommand cm3;
            //label14.Text = mealAllergens.ToString();
            //label15.Text = mealIDForAllergens.ToString();
            string query3 = "insert into Allergens values('" + mealAllergens + "'," + mealIDForAllergens + ")";
            cm3 = new SqlCommand(query3, conn);
            cm3.ExecuteNonQuery();
            cm3.Dispose();
            conn.Close();

        }
        private void LoadComboBoxDataWithMeal()
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string query = "SELECT * FROM Meals";
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
                        // Assuming mealID is in the first column (index 0), and mealName is in the second column (index 1)
                        int mealID = reader.GetInt32(0);
                        string mealName = reader.GetString(1);
                        int fat = reader.GetInt32(2);
                        int pro = reader.GetInt32(3);
                        int carb = reader.GetInt32(4);
                        int fb = reader.GetInt32(5);
                        // You can combine mealID and mealName into a single string or use them separately as per your requirement
                        string item = mealID.ToString() + " " + mealName + " " + fat.ToString() + " " + pro.ToString() + " " + carb.ToString() + " " + fb.ToString();
                        comboBox1.Items.Add(item);
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

        private void createworkoutplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            memberWorkOutPlan form = new memberWorkOutPlan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplan form = new dietplan(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            BookTrainingSession form = new BookTrainingSession(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackMember form = new FeedbackMember(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void Home_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            member form = new member(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkoutPlanReport form = new WorkoutPlanReport(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            DietPlanReport form = new DietPlanReport(userId);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
