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
    
    public partial class signupAdmin : Form
    {
        int AdminID;
        int adminAccountId;
        public signupAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string  
            conn.Open();
            SqlCommand cm, cm2, cm3, cm4;
            string uname = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            string name = textBox4.Text;
            string dob = textBox5.Text;
            string query1 = "insert into Account values('admin','" + password + "','" + uname + "','" + email + "')";
            cm = new SqlCommand(query1, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            string query2 = "select accountID from account where username='" + uname + "'";
            cm3 = new SqlCommand(query2, conn);
            object aID = cm3.ExecuteScalar();
            int accID = Convert.ToInt32(aID);
            string query3 = "insert into admin values('" + name + "'," + "convert(date,'" + dob + "')," + accID + ")";
            cm2 = new SqlCommand(query3, conn);
            cm2.ExecuteNonQuery();
            cm2.Dispose();
            string query4 = "select adminID from admin where accountID=" + accID;
            cm4 = new SqlCommand(query4, conn);
            object adID = cm3.ExecuteScalar();
            AdminID = Convert.ToInt32(aID);
            cm4.Dispose();
            conn.Close();
            this.Hide();
            admin form = new admin(AdminID);
            //admin form = new admin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void signupAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
