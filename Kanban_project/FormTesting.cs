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
using System.Data.SqlClient;

namespace Kanban_project
{
    public partial class FormTesting : Form
    {
        public FormTesting()
        {
            InitializeComponent();
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM tests", con.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.DataSource = table;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string Ids()
        {
            string id = textBox1.Text;
            return id;

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM tests where id = " + Ids() + "", con.getConnection());
            Program.testId = Convert.ToUInt64(Ids());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Form test = new FormTest();
                this.Hide();
                test.Show();
            }
            con.Close();
        }
    }
}
