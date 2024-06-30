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
    public partial class RemoveMember : Form
    {
        int gymOwnerID;
        int memberID;
        public RemoveMember(int gymOwnerID)
        {
            InitializeComponent();
            this.gymOwnerID = gymOwnerID;
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainer form = new AddTrainer(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveTrainer form = new RemoveTrainer(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {

        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerGym form = new registerGym(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void RemoveMember_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = comboBox1.Visible;
            LoadComboBoxDataWithMemberID();
        }

        private void LoadComboBoxDataWithMemberID()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                string query = "SELECT memberID FROM Member";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "removeMember");

                    // Bind the ComboBox
                    comboBox1.DisplayMember = "memberId";
                    comboBox1.DataSource = ds.Tables["removeMember"];
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

        private void done_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

            try
            {
                conn.Open();
                SqlCommand cm1, cm2, cm3, cm4;
                // Retrieve accountID of the trainer
                
                string query2 = "SELECT accountID FROM Member WHERE memberID=@memberId";
                cm3 = new SqlCommand(query2, conn);
                cm3.Parameters.AddWithValue("@memberId", memberID);
                object aID = cm3.ExecuteScalar();
                int accountIDofMember = (aID == null) ? -1 : Convert.ToInt32(aID);

                if (accountIDofMember != -1)
                {
                    // Delete the trainer record
                    string query3 = "DELETE FROM Member WHERE accountId=@accountId";
                    cm2 = new SqlCommand(query3, conn);
                    cm2.Parameters.AddWithValue("@accountId", accountIDofMember);
                    cm2.ExecuteNonQuery();

                    // Delete the account record
                    string query4 = "DELETE FROM Account WHERE accountId=@accountId";
                    cm4 = new SqlCommand(query4, conn);
                    cm4.Parameters.AddWithValue("@accountId", accountIDofMember);
                    cm4.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted");
                }
                else
                {
                    MessageBox.Show("Member account not found.");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    this.memberID = Convert.ToInt32(selectedRow["memberID"]);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Account Deactivated");
        }
    }
}
