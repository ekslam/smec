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
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        public Form main_form { get; set; }
        public string getuser { get; set; }

        public Form4()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_firstN"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_lastN"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_addr"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_contactno"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_email"].Value.ToString();
            label1.Text = dataGridView1.Rows[e.RowIndex].Cells["customer_ID"].Value.ToString();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                pictureBox2.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "First Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "First Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Last Name")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Last Name";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Home Address")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Home Address";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Contact Number")
            {
                textBox5.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Contact Number";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "E-mail Address")
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "E-mail Address";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM customer";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["customer_ID"].Visible = false;
            dataGridView1.Columns["customer_firstN"].HeaderText = "Firstname";
            
        }

        private void loadall()
        {
            string query = "SELECT * FROM customer";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["customer_ID"].Visible = false;
            dataGridView1.Columns["customer_firstN"].HeaderText = "Firstname";
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string query = ("INSERT INTO customer(customer_firstN, customer_lastN, customer_addr, customer_contactno, customer_email) " +
                                   "VALUES( '" + textBox1.Text + " ', '" + textBox2.Text + " ', '" + textBox3.Text +
                                   " ', '" + textBox5.Text + "', ' " + textBox4.Text + "' );");
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("User added");
            conn.Close();
            loadall();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string query = ("UPDATE customer SET customer_firstN = '" + textBox1.Text + "', customer_lastN = '" + textBox2.Text + "', customer_addr = '"
                + textBox3.Text + "', customer_contactno = '" + textBox5.Text + "', customer_email = '" + textBox4.Text + "' WHERE customer_ID = '" + label1.Text + "';");
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("User Details Updated");
            conn.Close();
            loadall();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            pictureBox2.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
