using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace menu
{
    public partial class crystal : Form
    {
        CrystalReport1 cr;
        public crystal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0,comboBox1.Text);
            crystalReportViewer2.ReportSource = cr;
        }

        private void crystal_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport1();
            foreach (ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues);
        }
    }
}
