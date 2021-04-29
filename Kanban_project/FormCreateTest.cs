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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) {
                MessageBox.Show("Истина/ложь");
                groupBox1.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 2) {
                groupBox2.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 3) {
                groupBox3.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 4) {
                groupBox4.Visible = true;
            }

            else if (comboBox1.SelectedIndex == 5) {
                groupBox5.Visible = true;
            }
        }
    }
}
