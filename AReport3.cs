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
    public partial class AReport3 : Form
    {
        int AdminID;
        public AReport3(int userId)
        {
            InitializeComponent();
            AdminID = userId;
        }
        
        private void Reject1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection sqlCon = new  SqlConnection (conString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select qname, count(trainer.trainerID) as number from trainer inner join TrainerQualifications on trainer.trainerID=TrainerQualifications.trainerID group by qname", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewForms form = new viewForms(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void AReport3_Load(object sender, EventArgs e)
        {

        }
    }
}
