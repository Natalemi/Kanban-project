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
            textBox2.Text = null;
            comboBox1.Text = null;

            // сохранить в переменную правильные ответы
            groupBox();

        }
    }
}
