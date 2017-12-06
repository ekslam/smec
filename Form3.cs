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
    public partial class Form3 : Form
    {
        public string getusername;
        public string oldpassw;

        MySqlConnection conn;
        public Form main_form { get; set; }

        public string getuser { get; set; }

        public Form3()
        {
            InitializeComponent();

            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }

        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //ADD USER VIEW
            string query = "SELECT * FROM tbl_user;";
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["userid"].Visible = false;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["fname"].HeaderText = "Firstname";

            //EDIT USER VIEW
            string query2 = "SELECT * FROM tbl_user WHERE fname = '" + getuser + "'";
            MySqlCommand com = new MySqlCommand(query2, conn);
            MySqlDataAdapter adpp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt2 = new DataTable();
            adpp.Fill(dt2);

            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["userid"].Visible = false;
            dataGridView2.Columns["fname"].HeaderText = "Firstname";

            string query3 = "SELECT * FROM tbl_user WHERE fname = '" + getuser + "'";
            MySqlCommand com2 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adppp = new MySqlDataAdapter(com2);
            conn.Close();
            DataTable dt3 = new DataTable();
            adpp.Fill(dt3);

            dataGridView3.DataSource = dt3;
            dataGridView3.Columns["userid"].Visible = false;
            dataGridView3.Columns["fname"].HeaderText = "Firstname";

            //DELETE VIEW
            string query4 = "SELECT * FROM tbl_user;";
            MySqlCommand com3 = new MySqlCommand(query4, conn);
            MySqlDataAdapter adpp3 = new MySqlDataAdapter(com3);
            conn.Close();
            DataTable dt4 = new DataTable();
            adpp3.Fill(dt4);

            dataGridView4.DataSource = dt4;
            dataGridView4.Columns["userid"].Visible = false;
            dataGridView4.Columns["fname"].HeaderText = "Firstname";

            //MAIN VIEW
            string nyez = "SELECT usertype FROM tbl_user WHERE fname = '" + getuser + "'";
            conn.Open();
            comm = new MySqlCommand(nyez, conn);
            adp = new MySqlDataAdapter(comm);
            conn.Close();
            dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows[0]["usertype"].ToString() == "1")
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void loadall()
        {
            //ADD USER VIEW
            string query = "SELECT * FROM tbl_user;";
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["userid"].Visible = false;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["fname"].HeaderText = "Firstname";

            //EDIT USER VIEW
            string query2 = "SELECT * FROM tbl_user WHERE fname = '" + getuser + "'";
            MySqlCommand com = new MySqlCommand(query2, conn);
            MySqlDataAdapter adpp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt2 = new DataTable();
            adpp.Fill(dt2);

            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["userid"].Visible = false;
            dataGridView2.Columns["fname"].HeaderText = "Firstname";

            //DELETE VIEW
            string query4 = "SELECT * FROM tbl_user;";
            MySqlCommand com3 = new MySqlCommand(query4, conn);
            MySqlDataAdapter adpp3 = new MySqlDataAdapter(com3);
            conn.Close();
            DataTable dt4 = new DataTable();
            adpp3.Fill(dt4);

            dataGridView4.DataSource = dt4;
            dataGridView4.Columns["userid"].Visible = false;
            dataGridView4.Columns["fname"].HeaderText = "Firstname";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                fname.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
                lname.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
                user.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                int typ = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["usertype"].Value.ToString());

                type.Text = "Administrator";
                if (typ == 2)
                {
                    type.Text = "Manager";
                }
                else if (typ == 3)
                {
                    type.Text = "Staff";
                }
                pass.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fname.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
            lname.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
            user.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
            int typ = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["usertype"].Value.ToString());
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            oldpass.Text = "";
            confirm1.Text = "";
            confirm2.Text = "";
        }

        private void confirm1_Enter(object sender, EventArgs e)
        {
            
        }

        private void confirm1_Leave(object sender, EventArgs e)
        {
        }

        private void confirm2_Enter(object sender, EventArgs e)
        {
            
        }

        private void confirm2_Leave(object sender, EventArgs e)
        {
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            main_form.Show();
        }

        private void confirm1_TextChanged(object sender, EventArgs e)
        {

        }

        private void oldpass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please input your desired username.");
            }
            else
            {
                String username = textBox5.Text;
                String query5 = "SELECT username FROM tbl_user" + " WHERE username ='" + username + "'";
                conn.Open();
                MySqlCommand com = new MySqlCommand(query5, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Username Already Taken!");
                }
                else
                {
                    string query = ("UPDATE tbl_user SET username = '" + textBox5.Text + "' WHERE fname = '" + getuser + "';");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Username has been updated.");
                    conn.Close();
                    loadall();


                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (oldpass.Text != "")
            {

                if (confirm1.Text != "" || confirm2.Text != "")
                {
                    if (confirm1.Text == confirm2.Text)
                    {
                        string query = ("UPDATE tbl_user SET password = '" + confirm1.Text + "' WHERE fname = '" + getuser + "';");
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(query, conn);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Password Updated");
                        conn.Close();
                        loadall();
                    }
                    else if (confirm1.Text != confirm2.Text)
                    {
                        MessageBox.Show("Passwords do not match");
                    }
                }
                else
                {
                    MessageBox.Show("Please input Password Credentials");
                }

            }
            else
            {
                MessageBox.Show("Please input Password Credentials");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (fname.Text == "" || lname.Text == "")
            {

                MessageBox.Show("Please fill out the required fields");
            }
            else
            {
                int utype = 0;
                if (type.Text == "Administrator")
                {
                    utype = 1;
                    type.Text = "Administrator";
                }
                else if (type.Text == "Manager")
                {
                    utype = 2;
                    type.Text = "Manager";
                }
                else if (type.Text == "Staff")
                {
                    utype = 3;
                    type.Text = "Staff";
                }
                string query = ("INSERT INTO tbl_user(fname, lname, usertype, username, password) " +
                               "VALUES('" + fname.Text + "', ' " + lname.Text + "', ' " + utype +
                               "', ' " + user.Text + "', ' " + pass.Text + "' );");
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("User added");
                conn.Close();
                loadall();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            fname.Text = "";
            lname.Text = "";
            type.Text = "";
            user.Text = "";
            pass.Text = "";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["lname"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
            int typ = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["usertype"].Value.ToString());
            label12.Text = dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString();
        }

        private void pictureBox9_Click(object sender, System.EventArgs e)
        {
            string query5 = ("DELETE from tbl_user WHERE userid = '" + label12.Text + "';");
            conn.Open();
            MySqlCommand comm5 = new MySqlCommand(query5, conn);
            
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this user?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                comm5.ExecuteNonQuery();
                loadall();
            }
            else if (dr == DialogResult.No)
            {
                
            }
                
            conn.Close();
            loadall();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
