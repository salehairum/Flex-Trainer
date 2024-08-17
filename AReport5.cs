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
    public partial class AReport5 : Form
    {
        string type;

        int AdminID;
        public AReport5(int userId)
        {
            InitializeComponent();
            AdminID = userId;
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (
                SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select * from membership where mtype='" + type+"'", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = comboBox1.SelectedItem.ToString();
        }

        private void AReport5_Load(object sender, EventArgs e)
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
