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
    public partial class Form5 : Form
    {
        MySqlConnection conn;
        public Form main_form { get; set; }
        public string getuser { get; set; }
        public Form5()
        {
            
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM product_store";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["product_ID"].Visible = false;
            dataGridView1.Columns["product_waranty"].Visible = false;
            dataGridView1.Columns["product_name"].HeaderText = "Product Name";

            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["product_selling_price"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["product_quantity"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["product_category"].Value.ToString();
            label1.Text = dataGridView1.Rows[e.RowIndex].Cells["product_ID"].Value.ToString();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

               pictureBox2.Enabled= false;
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Product Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Product Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Price")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Price";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Product Quantity")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Product Quantity";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Product Warranty")
            {
                textBox4.Text = "";
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Product Category";
                textBox4.ForeColor = Color.Gray;
            }
        }
        
        private void loadall()
        {
            string query = "SELECT * FROM product_store";
            //conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["product_ID"].Visible = false;
            dataGridView1.Columns["product_name"].HeaderText = "Product Name";

            //conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "Price" && textBox3.Text != "")
            {
                string query = ("INSERT INTO product_store(product_name, product_selling_price, product_quantity, product_category) " +
                              "VALUES( '" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "');");
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Item added");
                conn.Close();
                loadall();
            }
            else
            {
                MessageBox.Show("Please fill out the required fields");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string query = ("UPDATE product_store SET product_name = '" + textBox1.Text + "', product_selling_price= '" + textBox2.Text + "', product_quantity = '"
                + textBox3.Text + "', product_category = '" + textBox4.Text + "' WHERE product_ID = '" + label1.Text + "';");
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("Product Details Updated");
            conn.Close();
            loadall();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            pictureBox2.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string query5 = ("DELETE from product_store WHERE product_ID = '" + label1.Text + "';");
            conn.Open();
            MySqlCommand comm5 = new MySqlCommand(query5, conn);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this product?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                comm5.ExecuteNonQuery();
                loadall();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else if (dr == DialogResult.No)
            {

            }

            conn.Close();
            loadall();
        }
    }
}
