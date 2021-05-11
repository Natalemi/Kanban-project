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
    public partial class FormTable : Form
    {
        public FormTable()
        {
            InitializeComponent();
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM tab", con.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.user.teacher == true)
            {
                FormTeacher form = new FormTeacher();
                this.Hide();
                form.Show();
            }
            if (Program.user.teacher == false)
            {
                FormPupil form = new FormPupil();
                this.Hide();
                form.Show();
            }
        }

        private void FormTable_Load(object sender, EventArgs e)
        {

        }
    }
}
