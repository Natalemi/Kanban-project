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
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form FormPupil = new FormPupil();
                FormPupil.ShowDialog();
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                Form FormTeacher = new FormTeacher();
                FormTeacher.ShowDialog();
                this.Hide();
            }
        }
    }
}
