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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) {
                groupBox();
                groupBox1.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 1) {
                groupBox();
                groupBox2.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 2) {
                groupBox();
                groupBox3.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 3) {
                groupBox();
                groupBox4.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 4) {
                groupBox();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox14.Visible == false) {
                textBox14.Visible = true;
                radioButton5.Visible = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 37);
            }
            else if (textBox15.Visible == false) {
                textBox15.Visible = true;
                radioButton6.Visible = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 37);
            }
            else if (textBox16.Visible == false) {
                textBox16.Visible = true;
                radioButton7.Visible = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 37);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox17.Visible == false) {
                textBox17.Visible = true;
                checkBox3.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
            else if (textBox18.Visible == false) {
                textBox18.Visible = true;
                checkBox4.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
            else if (textBox19.Visible == false) {
                textBox19.Visible = true;
                checkBox5.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
            else if (textBox20.Visible == false) {
                textBox20.Visible = true;
                checkBox6.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
            else if (textBox21.Visible == false) {
                textBox21.Visible = true;
                checkBox7.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
            else if (textBox22.Visible == false) {
                textBox22.Visible = true;
                checkBox8.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 37);
            }
        }
    }
}
