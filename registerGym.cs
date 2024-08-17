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
    public partial class registerGym : Form
    {
        int gymOwnerID;
        public registerGym(int gymOwnerID)
        {
            InitializeComponent();
            this.gymOwnerID = gymOwnerID;
        }


        private void button1_Click(object sender, EventArgs e)
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

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveTrainer form = new RemoveTrainer(gymOwnerID);
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

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveMember form = new RemoveMember(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;SqlConnection conn = new SqlConnection(conString);//connection string 
            conn.Open();
            SqlCommand cm;
            string location = textBox2.Text;
            string size = comboBox1.Text;
            string type = comboBox2.Text;
            string activeMembers = textBox3.Text;
            string budget = textBox1.Text;
            /* string gymOwnerID = label20.Text;   user id here*/
            string query = "Insert into GymOwnerAppliesForGymReg values (" + gymOwnerID + ",'" + location + "','" + type + "','" + size + "'," + Convert.ToInt32(activeMembers) + "," + Convert.ToInt32(budget) + ")";
            cm = new SqlCommand(query, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            conn.Close();
        }

        private void registerGym_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Home_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            gymowner_cs form = new gymowner_cs(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }


        private void booktrainingsession_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            RemoveTrainer form = new RemoveTrainer(this.gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void createdietplan_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            RemoveMember form = new RemoveMember(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainer form = new AddTrainer(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            registerGym form = new registerGym(gymOwnerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
