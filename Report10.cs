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
    public partial class Report10 : Form
    {
        int AdminID;
        public Report10(int userId)
        {
            AdminID = userId;
            InitializeComponent();
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-E85OBQM\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select gymid, count(memberID) as numberOfMembers from member group by gymid having gymid IN(select gymid from gym where gymownerid IN(select gymownerid from gymowner where accountid in(select SUBSTRING(details, 9, 3) from AuditTrail where action='Add new Account' and substring(details, 31, 8)='gymowner')))", sqlCon);
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
    }
}
