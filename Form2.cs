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
    public partial class Form2 : Form
    {
        MySqlConnection conn;
        public Form login_form { get; set; }
        public String getuser { get; set; }
        public String gettext { get; set; }
        public Form2()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }
        public void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = this.getuser;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            f7.getuser = label2.Text;
            f7.main_form = this;
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Form4 f4 = new Form4();
            f4.Show();
            f4.main_form = this;
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string query = "SELECT usertype FROM tbl_user WHERE fname = '" + getuser + "'";
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows[0]["usertype"].ToString() == "1")
            {
                Form5 f5 = new Form5();
                f5.Show();
                f5.main_form = this;
                this.Hide();
                f5.getuser = label2.Text;
            }
            else if (dt.Rows[0]["usertype"].ToString() == "2") {
                Form5 f5 = new Form5();
                f5.Show();
                f5.main_form = this;
                this.Hide();
                f5.getuser = label2.Text;
            }
            else
            {
                pictureBox3.Enabled = false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
                Form3 f3 = new Form3();
                f3.getuser = label2.Text;
                f3.Show();
                f3.main_form = this;
                this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            login_form.Show(); 
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.gettext = textBox1.Text;
            f6.Show();
            f6.main_form = this;
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Hide();
        }*/
    }
}
