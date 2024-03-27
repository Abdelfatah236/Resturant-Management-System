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
    public partial class Form6 : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott;Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        int oid;


        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (Program.f)
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());



                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "total_cost";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("price", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("oid", oid);
                c.ExecuteNonQuery();

                double p = Convert.ToDouble(c.Parameters["price"].Value.ToString()) + 15;
                textBox2.Text = p.ToString();



                string cm = "select tname, price from item, order_items WHERE order_id =:ord and item_id = tid";
                adapter = new OracleDataAdapter(cm, ordb);
                adapter.SelectCommand.Parameters.Add("ord", oid);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            
        }
    }
}
