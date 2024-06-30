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
    public partial class viewForms : Form
    {
        public viewForms()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report2 form = new Report2();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report6 form = new Report6();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report8 form = new Report8();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report3 form = new Report3();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report4 form = new Report4();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report5 form = new Report5();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report7 form = new Report7();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report1 form = new Report1();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void viewForms_Load(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport1 form = new AReport1();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport2 form = new AReport2();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport3 form = new AReport3();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport4 form = new AReport4();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport5 form = new AReport5();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport6 form = new AReport6();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport7 form = new AReport7();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport8 form = new AReport8();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport9 form = new AReport9();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            AReport10 form = new AReport10();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report9 form = new Report9();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report10 form = new Report10();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
