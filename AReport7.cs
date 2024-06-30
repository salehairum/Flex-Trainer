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
    public partial class AReport7 : Form
    {
        public AReport7()
        {
            InitializeComponent();
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select meals.mealID, mealname,count(allergenName) as numberOfAllergens from allergens inner join meals on meals.mealID=Allergens.mealID group by meals.mealID,mealname", sqlCon);
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
