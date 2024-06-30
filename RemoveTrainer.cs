using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class RemoveTrainer : Form
    {
        int gymOwnerID;
        int trainerID;
        public RemoveTrainer(int gymOwnerId)
        {
            InitializeComponent();
            this.gymOwnerID = gymOwnerId;
        }

        private void RemoveTrainer_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = comboBox1.Visible;
            LoadComboBoxDataWithTrainerID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            using (gymowner_cs form = new gymowner_cs(gymOwnerID))
            form.ShowDialog();
            Show();
        }
        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerGym form = new registerGym(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {

        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainer form = new AddTrainer(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveMember form = new RemoveMember(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void LoadComboBoxDataWithTrainerID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT TrainerID FROM Trainer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "removeTrainer");

                    // Bind the ComboBox
                    comboBox1.DisplayMember = "TrainerID";
                    comboBox1.DataSource = ds.Tables["removeTrainer"];
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
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    this.trainerID = Convert.ToInt32(selectedRow["trainerID"]);

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void done_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cm1, cm2, cm3, cm4;
                // Retrieve accountID of the trainer
                string query2 = "SELECT accountID FROM Trainer WHERE trainerId=@trainerId";
                cm3 = new SqlCommand(query2, conn);
                cm3.Parameters.AddWithValue("@trainerId", trainerID);
                object aID = cm3.ExecuteScalar();
                int accountIDofTrainer = (aID == null) ? -1 : Convert.ToInt32(aID);

                if (accountIDofTrainer != -1)
                {

                    // Delete the trainer record from gym
                    string query1 = "DELETE FROM TrainerJoinsGym WHERE trainerId=@trainerId";
                    cm1 = new SqlCommand(query1, conn);
                    cm1.Parameters.AddWithValue("@trainerId", trainerID);
                    cm1.ExecuteNonQuery();

                    // Delete the trainer record
                    string query3 = "DELETE FROM Trainer WHERE accountId=@accountId";
                    cm2 = new SqlCommand(query3, conn);
                    cm2.Parameters.AddWithValue("@accountId", accountIDofTrainer);
                    cm2.ExecuteNonQuery();

                    // Delete the account record
                    string query4 = "DELETE FROM Account WHERE accountId=@accountId";
                    cm4 = new SqlCommand(query4, conn);
                    cm4.Parameters.AddWithValue("@accountId", accountIDofTrainer);
                    cm4.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted");
                }
                else
                {
                    MessageBox.Show("Trainer account not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., show error message
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            conn.Open();
            SqlCommand cm1;
            // Delete the trainer record from gym
            string query1 = "DELETE FROM TrainerJoinsGym WHERE trainerId=@trainerId";
            cm1 = new SqlCommand(query1, conn);
            cm1.Parameters.AddWithValue("@trainerId", trainerID);
            cm1.ExecuteNonQuery();
            MessageBox.Show("Trainer Account Deactivated");
        }
    }
}
