using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace smec
{

    public partial class Form7 : Form
    {
        public string get_item;
        public string get_name;
        public string info;

        MySqlConnection conn;
        public Form main_form { get; set; }
        public string final_name { get; set; }
        public string getuser { get; set; }

        public Form7()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
            this.panel1.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox7.Text = this.getuser;
            textBox8.Text = DateTime.Today.ToString("dd/MM/yyyy");


            string select = "SELECT * FROM order_line;";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp.Fill(dt2);

            if (dt2.Rows.Count != 0)
            {
                select = dt2.Rows[0][0].ToString();
            }

            Multiply();

        }
        public string count;
        public void Multiply()
        {
            int quantity = Convert.ToInt32(numericUpDown1.Value);
            int num = Convert.ToInt32(getprice);
            count = (num * quantity).ToString();
        }

        private void Form7_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "SELECT * FROM order_line;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["order_line_ID"].Visible = false;
            dataGridView1.Columns["warranty_status"].Visible = false;
            dataGridView1.Columns["customer_name"].HeaderText = "Customer";

            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void loadall()
        {
            panel2.Hide();
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox7.Text = this.getuser;
            textBox8.Text = DateTime.Today.ToString("dd/MM/yyyy");

            string query = "SELECT * FROM order_line;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);


            dataGridView1.DataSource = dt;
            dataGridView1.Columns["order_line_ID"].Visible = false;
            dataGridView1.Columns["warranty_status"].Visible = false;
            dataGridView1.Columns["customer_name"].HeaderText = "Customer";

            textBox4.Enabled = false;
            textBox5.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_name = textBox3.Text;

            string query3 = "SELECT * FROM customer WHERE customer_firstN LIKE '" + get_name + "%';";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView2.DataSource = dt3;
            dataGridView2.Columns["customer_ID"].Visible = false;
            dataGridView2.Columns["customer_lastN"].Visible = false;
            dataGridView2.Columns["customer_contactno"].Visible = false;
            dataGridView2.Columns["customer_addr"].Visible = false;
            dataGridView2.Columns["customer_email"].Visible = false;
            dataGridView2.Columns["customer_firstN"].HeaderText = "Firstname";

            info = "1";
            label9.Text = info;
            if (label9.Text == "1")
            {
                label12.Text = "Product List";
            }
            else if (label9.Text == "2")
            {
                label12.Text = "Customer List";
            }
            else
            {
                label12.Text = "";
            }
            panel1.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_item = textBox6.Text;

            string query2 = "SELECT * FROM product_store WHERE product_name LIKE '" + get_item + "%';";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            dataGridView2.Columns["product_ID"].Visible = false;
            dataGridView2.Columns["product_selling_price"].Visible = false;
            dataGridView2.Columns["product_quantity"].Visible = false;
            dataGridView2.Columns["product_waranty"].Visible = false;
            dataGridView2.Columns["product_name"].HeaderText = "Product Name";

            info = "2";
            label9.Text = info;
            if (label9.Text == "1")
            {
                label12.Text = "Product List";
            }
            else if (label9.Text == "2")
            {
                label12.Text = "Customer List";
            }
            else
            {
                label12.Text = "";
            }
            this.panel1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel1.Hide();
            textBox3.Text = "";
            textBox6.Text = "";
            label12.Text = "";
        }

        public string getprice;

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (info == "1")
            {
                string selected_fn;
                string selected_ln;

                selected_fn = dataGridView2.Rows[e.RowIndex].Cells["customer_firstN"].Value.ToString();
                selected_ln = dataGridView2.Rows[e.RowIndex].Cells["customer_lastN"].Value.ToString();

                textBox3.Text = selected_fn;
                textBox4.Text = selected_ln;
                this.panel1.Hide();
                get_custID();

            }

            else
            {
                selected_name = dataGridView2.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                selected_price = dataGridView2.Rows[e.RowIndex].Cells["product_selling_price"].Value.ToString();

                textBox6.Text = selected_name;
                textBox5.Text = selected_price;


                getprice = selected_price;
                this.panel1.Hide();

                get_prodID();
            }
        }

        private string selected_name;
        private string selected_price;

        private void get_custID()
        {
            string select = ("SELECT customer_ID from customer WHERE customer_firstN = '" + textBox3.Text + "'");
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp.Fill(dt2);

            if (dt2.Rows.Count != 0)
            {
                label10.Text = dt2.Rows[0][0].ToString();
            }
        }

        private void get_prodID()
        {
            string select = "SELECT product_ID from product_store WHERE product_name = '" + textBox6.Text + "'";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp.Fill(dt2);

            if (dt2.Rows.Count != 0)
            {
                label11.Text = dt2.Rows[0][0].ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( numericUpDown1.Value ==0 && textBox2.Text =="" && textBox5.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("Please place order.");
            }
            else
            {
                int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));

                string query = ("INSERT INTO order_line(customer_ID, product_ID, product_quant, product_price_sold, warranty_status) " +
                                   "VALUES('" + label10.Text + "', ' " + label11.Text + "', ' " + count +
                                   "', ' " + textBox2.Text + "', 'none' );");
                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm2);
                MessageBox.Show("Order placed");
                conn.Close();
                loadall();

                Multiply(); 
            }
            
        }

        public string pricesss;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int price = int.Parse(textBox5.Text);
            int num = int.Parse(numericUpDown1.Value.ToString());
            int final = price * num;
            textBox2.Text = final.ToString();
            pricesss = final.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string temp = numericUpDown1.Value.ToString();
            int con = Convert.ToInt32(temp);
            string name = textBox3.Text + " " + textBox4.Text;
            string query = ("INSERT INTO order_line(customer_name, product_name, product_quant, product_price_sold, warranty_status) " +
                               "VALUES('" + name + "', ' " + textBox6.Text + "', ' " + con +
                               "', ' " + textBox2.Text + "', 'none' );");
            Multiply();
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query, conn);
            comm2.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(comm2);
            Console.WriteLine(query);
            MessageBox.Show("Order placed");
            conn.Close();
            loadall();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            texxxx.Text = pricesss;
        }
    }
}
