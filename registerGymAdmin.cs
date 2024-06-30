using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class registerGymAdmin : Form
    {
        int AdminID;
        int gymOwnerId;
        string gymloc;
        string plan;
        string size;
        int activemems;
        int budget;
        public registerGymAdmin(int aId)
        {
            InitializeComponent();
            this.AdminID= aId;
        }

        private int currentRecordIndex = 0;
        int totalRecords = 0; // Stores the total number of records
        private void registerGymAdmin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();

            string query = "SELECT * FROM GymOwnerAppliesForGymReg";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader(); // Execute the query and get a reader

            // Loop through each record and count them
            while (reader.Read())
            {
                gymOwnerId = reader.GetInt32(0);
                gymloc = reader.GetString(1);
                plan = reader.GetString(2);
                size = reader.GetString(3);
                activemems = reader.GetInt32(4);
                budget = reader.GetInt32(5);

                // You can update your form labels here or store the data for later display

                totalRecords++; // Increment counter for each record
            }

            reader.Close();

            // Assuming there are records, display the first one
            if (totalRecords > 0)
            {
                string query1 = "SELECT * FROM GymOwnerAppliesForGymReg";
                SqlCommand cmd1 = new SqlCommand(query1, conn);

                reader = cmd1.ExecuteReader();
                reader.Read(); // Move to the first record

                gymOwnerId = reader.GetInt32(0);
                gymloc = reader.GetString(1);
                plan = reader.GetString(2);
                size = reader.GetString(3);
                activemems = reader.GetInt32(4);
                budget = reader.GetInt32(5);

                // Update your form labels or display the data
                label8.Text = "Gym Owner Id: " + gymOwnerId;
                label9.Text = "Location: " + gymloc;
                label3.Text = "Size of Facility: " + size;
                label2.Text = "Business Plan: " + plan;
                label7.Text = "Number of Active Members: " + activemems;

                currentRecordIndex++;
            }

            else
            {
                MessageBox.Show("No Gym Registration Requests yet.");
                this.Hide();
                admin form = new admin(AdminID);
                form.Show();
                form.FormClosed += (s, argc) => this.Close();
            }
            reader.Close();
            conn.Close();
        }

        private void Reject1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query1 = "delete from GymOwnerAppliesForGymReg where gymownerID = @id";
            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@id", gymOwnerId);
                cmd.ExecuteNonQuery();
            }

            this.Hide();
            admin form = new admin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }


        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin form = new admin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            removeGym form = new removeGym(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            viewForms form = new viewForms();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Approve1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string query1 = "INSERT INTO Gym (gLocation, businessPlan, size, nActiveMembers, budget, gymOwnerID) VALUES (@gymloc, @plan, @size, @activemems, @budget, @gymownerId)";

            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@gymloc", gymloc);
                cmd.Parameters.AddWithValue("@plan", plan);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@activemems", activemems);
                cmd.Parameters.AddWithValue("@budget", budget);
                cmd.Parameters.AddWithValue("@gymownerId", gymOwnerId);
                cmd.ExecuteNonQuery();
            }

            string query2 = "delete from GymOwnerAppliesForGymReg where gymOwnerId = @id";
            using (SqlCommand cmd2 = new SqlCommand(query2, conn))
            {
                cmd2.Parameters.AddWithValue("@id", gymOwnerId);
                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Gym Registered");

            this.Hide();
            admin form = new admin(AdminID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
