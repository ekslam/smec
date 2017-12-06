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
using System.Data.SqlClient;


namespace smec
{
    public partial class Form8 : Form
    {
        public string get_item;
        public string get_name;
        public string info;
        DataSet ds2;

        MySqlConnection conn;
        public Form main_form { get; set; }
        public string final_name { get; set; }
        public string getuser { get; set; }

        public Form8()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                get_item = textBox1.Text;
                SqlConnection conn3 = new SqlConnection();
                /*conn3.ConnectionString = "Data Source=.SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
                conn3.Open();

                SqlDataAdapter catSearch = new SqlDataAdapter("SELECT product_category FROM product_store", conn3);

                ds2 = new DataSet();
                catSearch.Fill(ds2, "catSearch");
                comboBox1.ValueMember = "product_category";
                comboBox1.DataSource = ds2.Tables["catSearch"];
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Enabled = true;*/

            if (textBox1.Text == "") {
                
                conn.Open();
                string query2 = "SELECT * FROM product_store;";
                MySqlCommand comm2 = new MySqlCommand(query2, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                
                dataGridView1.Columns["product_ID"].Visible = false;
                dataGridView1.Columns["product_selling_price"].Visible = false;
                dataGridView1.Columns["product_quantity"].Visible = false;
                dataGridView1.Columns["product_waranty"].Visible = false;
                dataGridView1.Columns["product_name"].HeaderText = "Product Name";
            }
            else {
               
                conn.Open();
                string query2 = "SELECT * FROM product_store WHERE product_name LIKE '%" + get_item + "%';";
                MySqlCommand comm2 = new MySqlCommand(query2, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                dataGridView1.DataSource = dt2;

                dataGridView1.Columns["product_ID"].Visible = false;
                dataGridView1.Columns["product_selling_price"].Visible = false;
                dataGridView1.Columns["product_quantity"].Visible = false;
                dataGridView1.Columns["product_waranty"].Visible = false;
                dataGridView1.Columns["product_name"].HeaderText = "Product Name";
                
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Product Name")
            {
                textBox1.Text = "";

            }
        }

        private void Form8_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = null;
           
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string query = ("SELECT product_category FROM product_store;");
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    }
}
