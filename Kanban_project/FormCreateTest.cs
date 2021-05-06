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
    public partial class FormCreateTest : Form
    {
        public FormCreateTest() {
            InitializeComponent();

        }

        int groupBox() {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;

            return 0;
        }

        void cleareTextBox() {
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            comboBox1.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) {
                groupBox();
                groupBox1.BringToFront();
                groupBox1.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 1) {
                groupBox();
                groupBox2.BringToFront();
                groupBox2.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 2) {
                groupBox();
                groupBox3.BringToFront();
                groupBox3.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 3) {
                groupBox();
                groupBox4.BringToFront();
                groupBox4.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 4) {
                groupBox();
                groupBox5.BringToFront();
                groupBox5.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int text1 = Convert.ToInt32(label10.Text);
            text1 += 1;
            label10.Text = Convert.ToString(text1);

            // сохранить в переменную textBox2
            cleareTextBox();
            

            // сохранить в переменную правильные ответы
            groupBox();

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тест успешно сохранён. Его можно найти в 'Мои тесты'");
            Form FormTeacher = new FormTeacher();
            // закрыть эту форму
            this.Hide();
            FormTeacher.ShowDialog();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int x = button1.Location.X;
            int y = button1.Location.Y;

            TextBox textBox = new TextBox();
            textBox.Size = textBox3.Size;

            RadioButton radioButton = new RadioButton();
            radioButton.Left = x - 21;
            radioButton.Top = y - 5;

            textBox.Left = x;
            textBox.Top = y - 5;

            groupBox2.Controls.Add(textBox);
            groupBox2.Controls.Add(radioButton);

            button1.Left = x;
            button1.Top = y + 28;

        }

        public void button2_Click(object sender, EventArgs e)
        {
            int x = button2.Location.X;
            int y = button2.Location.Y;

            TextBox textBox = new TextBox();
            textBox.Size = textBox3.Size;

            CheckBox checkBox = new CheckBox();
            checkBox.Left = x - 21;
            checkBox.Top = y - 5;

            textBox.Left = x;
            textBox.Top = y - 5;

            groupBox3.Controls.Add(textBox);
            groupBox3.Controls.Add(checkBox);

            button2.Left = x;
            button2.Top = y + 28;


        }

        private void FormCreateTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormCreateTest_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = button1.Location.X;
            int y = button1.Location.Y;

            TextBox textBox = new TextBox();
            textBox.Size = textBox3.Size;

            textBox.Left = x;
            textBox.Top = y - 5;

            groupBox5.Controls.Add(textBox);

            button1.Left = x;
            button1.Top = y + 28;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
