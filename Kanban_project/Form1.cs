using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (textBox1.Text == "Учитель") {
                Form FormTeacher = new FormTeacher();
                this.Hide();
                FormTeacher.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Паша Фень\nНаталия Лемиш\nАлексей Нелепа\nДанил Гращенков\nНикита Бородин");
        }
    }
}