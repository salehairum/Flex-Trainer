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
    public partial class AReport4 : Form
    {
        int rating;

        int AdminID;
        public AReport4(int userId)
        {
            InitializeComponent();
            AdminID = userId;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rating = Convert.ToInt32(comboBox1.SelectedItem);            
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select * from FeedbackTrainer where rating="+rating, sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void label2_Click(object sender, EventArgs e)
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
