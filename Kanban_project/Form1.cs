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

namespace Kanban_project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormRegistration = new FormRegistration();
            this.Hide();
            FormRegistration.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String email = emailField.Text;
            String password = passwordField.Text;

            if (email == "")
            {
                MessageBox.Show("email не должен быть пустым");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("password не должен быть пустым");
                return;
            }

           
            // код который может выбросить ошибку 
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE email = '" + email + "' AND password = '" + password + "' LIMIT 1;", con.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

            
            if (table.Rows.Count > 0)
            {
                UInt64 id = table.Rows[0].Field<UInt64>("id");
                email = table.Rows[0].Field<string>("email");
                password = table.Rows[0].Field<string>("password");
                string name = table.Rows[0].Field<string>("name");
                bool teacher = table.Rows[0].Field<bool>("teacher");

                User user = new User(id, email,  password, name, teacher);
                Program.InstalUser(user);

                if (teacher == true)
                {
                    Form FormTeacher = new FormTeacher();
                    this.Hide();
                    FormTeacher.Show();
                }
                else
                {
                    Form FormPupil = new FormPupil();
                    this.Hide();
                    FormPupil.Show();
                }
            }
            else
            {
                MessageBox.Show("Не хочет");
            }
     

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Паша Фень\nНаталия Лемиш\nАлексей Нелепа\nДанил Гращенков\nНикита Бородин");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}