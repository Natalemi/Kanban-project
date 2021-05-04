using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kanban_project
{
    public partial class FormRegistration : Form
    {
        Conection con;

        public FormRegistration()
        {
            System.Diagnostics.Debug.WriteLine("запуск");
            InitializeComponent();
            con = new Conection();
            con.Open();
            System.Diagnostics.Debug.WriteLine("запуск стоп");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = emailField.Text;
            string name = nameField.Text;
            string password = passwordField.Text;
            bool teacher = teacherBox.Checked;
            string query = "INSERT INTO users(email, password, name, teacher) VALUES ('" + email + "','" + password + "','" + name +"'," + teacher + ");";
            System.Diagnostics.Debug.WriteLine(query);

            if (name == "")
            {
                MessageBox.Show("name не должен быть пустым");
                return;
            }
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
                con.ExecuteNonQuery(query);
                // код который может выбросить ошибку  
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // код который должен выполнится если произошла ошибка, мы отображаем сообщение про ошибку
                MessageBox.Show(ex.Message);
            }

        }

        private void FormRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void teacherRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
