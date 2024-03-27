using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;

namespace menu
{
    public partial class Form7 : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott;Password=tiger;";
        OracleConnection conn;
        int id = 0;

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        double old_id;

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            string cm = "select cid,c_name, email, address, phone_number from customer where c_name =:n and c_password =:pass";
            adapter = new OracleDataAdapter(cm, ordb);
            adapter.SelectCommand.Parameters.Add("n", Program.n);
            adapter.SelectCommand.Parameters.Add("pass", Program.p);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "GetID";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("n", Program.n);
            c.Parameters.Add("r", Program.p);
            c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            c.ExecuteNonQuery();
            id = Convert.ToInt32(c.Parameters["id"].Value.ToString());

            c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "get_wish_list";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", id);
            c.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                wishlist.Items.Add(dr[0]);
            }

            c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "get_orders";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", id);
            c.Parameters.Add("oid", OracleDbType.RefCursor, ParameterDirection.Output);

            dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cm2 = "select tname, price from item, order_items WHERE order_id =:id and item_id = tid";
            OracleDataAdapter adb = new OracleDataAdapter(cm2, ordb);
            adb.SelectCommand.Parameters.Add("id",comboBox1.SelectedItem);
            DataSet d = new DataSet();
            adb.Fill(d);
            dataGridView2.DataSource = d.Tables[0];

        }
        private void button3_Click(object sender, EventArgs e)
        {
          
            try
            {
                builder = new OracleCommandBuilder(adapter);
                adapter.Update(ds.Tables[0]);
                MessageBox.Show("profile updated");
            }
            catch
            {
                MessageBox.Show("profile not updated, invailld operation");
            }
            
            

        }
    }
}
