﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kanban_project
{
    public partial class FormPupil : Form
    {
        public FormPupil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormPupil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
