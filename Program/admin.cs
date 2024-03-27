using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 reg = new Form1();
            reg.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 reg = new Form4();
            reg.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 reg = new Form5();
            reg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 reg = new Form7();
            reg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crystal reg = new crystal();
            reg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 reg = new Form6();
            reg.Show();
        }
    }
}
