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
        Conection con;
        public Form1()
        {
            System.Diagnostics.Debug.WriteLine("запуск");
            InitializeComponent();
            con = new Conection();
            con.Open();
            System.Diagnostics.Debug.WriteLine("запуск стоп");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormRegistration = new FormRegistration();
            this.Hide();
            FormRegistration.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = emailField.Text;
            string password = passwordField.Text;
            string query = "SELECT * FROM users WHERE email = ‘" + email + "’ and password = ‘" + password + "’ LIMIT 1;";
            System.Diagnostics.Debug.WriteLine(query);

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

            try
            {
                // код который может выбросить ошибку  
                if (con.ExecuteReader(query).Read())
                {
                    FormTeacher FormTeacher = new FormTeacher();
                    FormTeacher.Show();
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                // код который должен выполнится если произошла ошибка, мы отображаем сообщение про ошибку
                MessageBox.Show(ex.Message);
            }
            con.Close();
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
    }
}