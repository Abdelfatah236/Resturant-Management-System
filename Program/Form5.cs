using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace menu
{
    public partial class Form5 : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott;Password=tiger;";
        OracleConnection conn;

        public Form5()
        {
            InitializeComponent();
        }
        


        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("admin") && textBox2.Text.Equals("admin"))
            {
                this.Visible = false;
                admin reg = new admin();
                reg.Show();
            }
            else
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select c_name,c_password from customer where c_name =:cna and c_password =:pass";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("cna", textBox1.Text.ToString());
                cmd.Parameters.Add("pass", Convert.ToInt32(textBox2.Text));
                OracleDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("Invalid Username or Password ");
                }
                else
                {
                    Program.n = textBox1.Text;
                    Program.p = Convert.ToInt32(textBox2.Text);
                    this.Visible = false;
                    Form7 reg = new Form7();
                    reg.Show();
                }
            }
        }
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }
    }
}
