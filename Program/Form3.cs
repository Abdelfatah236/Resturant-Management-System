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
    public partial class Form3 : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott;Password=tiger;";
        OracleConnection conn;
        int id;
        int tid;
        int oid;
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Onion Rings");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Onion Rings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            Form5 f = new Form5();
            c.CommandText = "GetID";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("n", Program.n);
            c.Parameters.Add("r", Program.p);
            c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            c.ExecuteNonQuery();

            id = Convert.ToInt32(c.Parameters["id"].Value.ToString());
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Chicken Wings");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Chicken Wings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Chicken Wings");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Chicken Wings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Cheese Fries");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cheese Fries");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Nugets");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Nugets");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Hot Fries");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Hot Fries");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Coca Cola");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Coca Cola");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Apple Juice");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Apple Juice");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Tea");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Tea");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Coffee");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Coffee");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Smoothy");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Smoothy");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Pepsi");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Pepsi");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Milk chek");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Milk chek");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Mano");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Mano");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Cakes");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cakes");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Custards");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Custards");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Cheese Cake");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cheese Cake");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Molten Cake");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Molten Cake");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Ice Cream");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Ice Cream");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Wafel");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Wafel");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.f)
            {
                string message = "Do you want to create order!";
                string title = "Create Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into orders values(O_ID.NEXTVAL,:id)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", id);
                    c.ExecuteNonQuery();
                    MessageBox.Show("order created!");

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "Get_last_order";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.ExecuteNonQuery();
                    oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "get_item_id";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                    c.Parameters.Add("name", "Big Roll");
                    c.ExecuteNonQuery();
                    tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                    c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("i", tid);
                    c.Parameters.Add("d", oid);
                    c.ExecuteNonQuery();
                    MessageBox.Show("item added in order!");

                    Program.f = true;
                }
                else
                {
                    MessageBox.Show("order not created!");
                }
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Get_last_order";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.ExecuteNonQuery();
                oid = Convert.ToInt32(c.Parameters["id"].Value.ToString());


                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Big Roll");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into order_items values(:i,:d,orid.NEXTVAL)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("d", oid);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in order!");
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Onion Rings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Onion Rings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Chicken Wings");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cheese Fries");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Nugets");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Hot Fries");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Coca Cola");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Apple Juice");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Tea");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Coffee");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Smoothy");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Pepsi");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Milk chek");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Mano");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cakes");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Custards");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Cheese Cake");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Molten Cake");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Ice Cream");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Wafel");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_item_id";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                c.Parameters.Add("name", "Big Roll");
                c.ExecuteNonQuery();
                tid = Convert.ToInt32(c.Parameters["id"].Value.ToString());

                c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into FAVORITE_ITEM values(:i,:c)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("i", tid);
                c.Parameters.Add("c", id);
                c.ExecuteNonQuery();
                MessageBox.Show("item added in wish list!");
            }

            catch
            {
                MessageBox.Show("item already added in wish list!");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            this.Hide();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
        }
    }
}
