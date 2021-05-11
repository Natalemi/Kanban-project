using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kanban_project
{
    public partial class FormTeacher : Form
    {
        public FormTeacher()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form FormCreateTest = new FormCreateTest();
            this.Hide();
            FormCreateTest.ShowDialog();
        }

        private void FormTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formTesting = new FormTesting();
            this.Hide();
            formTesting.Show();
        }
    }
}
