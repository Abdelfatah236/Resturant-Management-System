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
    public partial class Form4 : Form
    {

        string ordb = "Data Source=ORCL; User Id=scott;Password=tiger;";
        OracleConnection conn;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            try {
                cmd.CommandText = "sign_up";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("name", textBox1.Text);
                cmd.Parameters.Add("address", textBox4.Text);

                cmd.Parameters.Add("mail", textBox2.Text);

                cmd.Parameters.Add("phone", Convert.ToInt32(textBox5.Text));

                if (textBox5.Text.Equals(textBox6.Text))
                    cmd.Parameters.Add("password", Convert.ToInt32(textBox3.Text));
                else
                    MessageBox.Show("password and confirm is not equals");

                if (radioButton1.Checked)
                    cmd.Parameters.Add("gender", "male");
                else
                    cmd.Parameters.Add("gender", "female");

                cmd.ExecuteNonQuery();

                MessageBox.Show("sign up seccessfully!");
                textBox1.Text = "username";
                textBox2.Text = "E-Mail";
                textBox3.Text = "Phone Number";
                textBox4.Text = "Address";
                textBox5.Text = "Password";
                textBox6.Text = "Confirm Password";
                radioButton1.Checked = false;
                radioButton2.Checked = false;


                Form5 f = new Form5();
                f.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("palese check data you insert!");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Dispose();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }



        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();

        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "E-mail";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Phone Number";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Addrerss";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Password";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Confirm Password";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
