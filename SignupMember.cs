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
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class SignupMember : Form
    {
        int memberID;
        int gymID;
        public SignupMember()
        {
            InitializeComponent();
            LoadComboBoxDataWithGym();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            SqlCommand cm, cm2, cm3, cm4;
            string uname = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            string name = textBox4.Text;
            string dob = textBox5.Text;
            string query1 = "insert into Account values('member','" + password + "','" + uname + "','" + email + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            string query2 = "select accountID from account where username='" + uname + "' and atype='member'";
            cm3 = new SqlCommand(query2, conn);
            object userID = cm3.ExecuteScalar();
            int accID = Convert.ToInt32(userID);
            cm3.Dispose();
            string query3 = "insert into member values('" + name + "',convert(date,'" + dob + "'),'active'," + accID +","+ gymID + ")";
            cm2 = new SqlCommand(query3, conn);
            cm2.ExecuteNonQuery();
            cm2.Dispose();
            string query4 = "select memberID from member where accountID=" + accID;
            cm4 = new SqlCommand(query4, conn);
            object mID = cm4.ExecuteScalar();
            memberID = Convert.ToInt32(mID);
            cm4.Dispose();

            if (comboBox3.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                string duration = comboBox3.SelectedItem.ToString();
                string mtype = comboBox2.SelectedItem.ToString();
                SqlCommand cm5;
                string query5 = "insert into membership values('" + duration + "','" + mtype + "'," + memberID + ")";
                cm5 = new SqlCommand(query5, conn);
                cm5.ExecuteNonQuery();
                cm5.Dispose();
            }
            conn.Close();

            this.Hide();
            member form = new member(memberID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedValue = comboBox1.SelectedItem.ToString();
                string temp = "";
                for (int i = 0; selectedValue[i] != ' '; i++)
                {
                    temp += selectedValue[i];
                }
                gymID = Convert.ToInt32(temp);
            }
        }
        private void LoadComboBoxDataWithGym()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))//connection string 
            {
                string query = "SELECT gymID,gLocation FROM Gym";
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
                        int gymID = reader.GetInt32(0);
                        string gymLocation = reader.GetString(1);
                        string item = gymID.ToString() + " " + gymLocation;
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

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
