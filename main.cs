using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void Member_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginMember form = new LoginMember();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();

        }

        private void Trainer_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginTrainer form = new loginTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Hide();
            //using (LoginMember form = new LoginMember())
            //    form.ShowDialog();

        }

        private void trainerr_Click(object sender, EventArgs e)
        {
            //Hide();
            //using (loginTrainer form = new loginTrainer())
            //    form.ShowDialog();

        }

        private void gymownerr_Click(object sender, EventArgs e)
        {
            //Hide();
            //using (loginGymowner form = new loginGymowner())
            //    form.ShowDialog();

        }

        private void adminn_Click(object sender, EventArgs e)
        {
            //Hide();
            //using (loginAdmin form = new loginAdmin())
            //    form.ShowDialog();
            // my name is anoosha ali

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gymowner_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginGymowner form = new loginGymowner();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginAdmin form = new loginAdmin();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void gymowner_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            loginGymowner form = new loginGymowner();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void admin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            loginAdmin form = new loginAdmin();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
