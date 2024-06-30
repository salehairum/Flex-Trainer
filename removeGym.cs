using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class removeGym : Form
    {
        int AdminID;
        int gymID;
        public removeGym(int aId)
        {
            InitializeComponent();
            this.AdminID=aId;
        }

        private void removeGym_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = comboBox1.Visible;
            LoadComboBoxDataWithGymID();
        }

        private void LoadComboBoxDataWithGymID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT gymID FROM Gym";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "removeGym");

                    // Bind the ComboBox
                    comboBox1.DisplayMember = "gymID";
                    comboBox1.DataSource = ds.Tables["removeGym"];
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            using (admin form = new admin(AdminID))
            form.ShowDialog();
            Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin form = new admin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerGymAdmin form = new registerGymAdmin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewForms form = new viewForms();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    this.gymID = Convert.ToInt32(selectedRow["gymID"]);

                }
            }
        }

        private void done_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cm1, cm2, cm3, cm4, cm5, cm6;

                // Update member status 
                string query2 = "update Member set status = 'inactive', gymID = null where gymID=@gymId";
                cm3 = new SqlCommand(query2, conn);
                cm3.Parameters.AddWithValue("@gymId", gymID);
                cm3.ExecuteNonQuery();

                //delete from TrainerJoins gym
                string query3 = "delete from TrainerJoinsGym where gymID=@gymId";
                cm4 = new SqlCommand(query3, conn);
                cm4.Parameters.AddWithValue("@gymId", gymID);
                cm4.ExecuteNonQuery();

                //delete feedback of gym
                string query4 = "delete from FeedbackGym where gymID=@gymId";
                cm5 = new SqlCommand(query4, conn);
                cm5.Parameters.AddWithValue("@gymId", gymID);
                cm5.ExecuteNonQuery();

                //delete from AdminManagesGym
                string query5 = "delete from AdminManagesGym where gymID=@gymId";
                cm6 = new SqlCommand(query5, conn);
                cm6.Parameters.AddWithValue("@gymId", gymID);
                cm6.ExecuteNonQuery();

                //delete gym
                string query6 = "delete from Gym where gymID=@gymId";
                cm2 = new SqlCommand(query6, conn);
                cm2.Parameters.AddWithValue("@gymId", gymID);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Gym Deleted");
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

            conn.Open();
            SqlCommand cm1;

            //delete from AdminManagesGym
            string query1 = "delete from AdminManagesGym where gymID=@gymId";
            cm1 = new SqlCommand(query1, conn);
            cm1.Parameters.AddWithValue("@gymId", gymID);
            cm1.ExecuteNonQuery();
            MessageBox.Show("Gym Deactivated");

        }
    }
}
