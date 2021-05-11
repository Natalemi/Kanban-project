using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Kanban_project
{
    public partial class FormCreateTest : Form
    {
        Conection con;
        Test test;

        public FormCreateTest() {
            InitializeComponent();
            con = new Conection();
            con.Open();
        }
       
        void questionLogic()
        {
            String LogicQuestion = text_Box.Text;
            String TypicalQuestion = tp_Box.Text;

            QuestionLogic question = new QuestionLogic();
            question.TrueAnswer = true_radioButton.Text;
            question.FalseAnswer = false_radioButton.Text;

            if (true_radioButton.Checked == true)
                question.CorrectAnswer = true_radioButton.Checked;

            String data = JsonSerializer.Serialize<QuestionLogic>(question);

            MySqlCommand query = new MySqlCommand("INSERT INTO question(id, test_id, text, type, data) VALUES (NULL, @id, @LogicQuestion, @TypicalQuestion, @data);", con.getConnection());
            query.Parameters.AddWithValue("@id", test.id);
            query.Parameters.AddWithValue("@LogicQuestion", LogicQuestion);
            query.Parameters.AddWithValue("@TypicalQuestion", TypicalQuestion);
            query.Parameters.AddWithValue("@data", data);
            System.Diagnostics.Debug.WriteLine(test.id);


            UInt64 questiId = (UInt64)con.ExecuteNonQuery(query);
            Question questi = new Question(questiId, test.id, LogicQuestion, TypicalQuestion, data);
        }

        void questionLogicText()
        {
            String LogicQuestion = text_Box.Text;
            String TypicalQuestion = tp_Box.Text;

            QuestionLogicText question = new QuestionLogicText();
            question.CorrectAnswer = word_Box.Text;


            String data = JsonSerializer.Serialize<QuestionLogicText>(question);

            MySqlCommand query = new MySqlCommand("INSERT INTO question(id, test_id, text, type, data) VALUES (NULL, @id, @LogicQuestion, @TypicalQuestion, @data);", con.getConnection());
            query.Parameters.AddWithValue("@id", test.id);
            query.Parameters.AddWithValue("@LogicQuestion", LogicQuestion);
            query.Parameters.AddWithValue("@TypicalQuestion", TypicalQuestion);
            query.Parameters.AddWithValue("@data", data);
            System.Diagnostics.Debug.WriteLine(test.id);


            UInt64 questiId = (UInt64)con.ExecuteNonQuery(query);
            Question questi = new Question(questiId, test.id, LogicQuestion, TypicalQuestion, data);
        }

        void questionLogicMultipleOne()
        {
            String LogicQuestion = text_Box.Text;
            String TypicalQuestion = tp_Box.Text;

            QuestionLogicTextMultipleOne question = new QuestionLogicTextMultipleOne();
            question.TrueAnswer = textBox.Text;
            question.FalseAnswer = textBox1.Text;

            if (radioButton.Checked == true)
                question.CorrectAnswer = radioButton.Checked;

            String data = JsonSerializer.Serialize<QuestionLogicTextMultipleOne>(question);

            MySqlCommand query = new MySqlCommand("INSERT INTO question(id, test_id, text, type, data) VALUES (NULL, @id, @LogicQuestion, @TypicalQuestion, @data);", con.getConnection());
            query.Parameters.AddWithValue("@id", test.id);
            query.Parameters.AddWithValue("@LogicQuestion", LogicQuestion);
            query.Parameters.AddWithValue("@TypicalQuestion", TypicalQuestion);
            query.Parameters.AddWithValue("@data", data);
            System.Diagnostics.Debug.WriteLine(query);
            System.Diagnostics.Debug.WriteLine(test.id);


            UInt64 questiId = (UInt64)con.ExecuteNonQuery(query);
            Question questi = new Question(questiId, test.id, LogicQuestion, TypicalQuestion, data);
        }

        void questionLogicMultipleMultiple()
        {
            String LogicQuestion = text_Box.Text;
            String TypicalQuestion = tp_Box.Text;

            QuestionLogicMultipleMultiple question = new QuestionLogicMultipleMultiple();

            question.Text = lots_textBox.Text;
            question.Text1 = lots_textBox1.Text;
            question.Text2 = lots_textBox2.Text;

            if (checkBox.Checked == true)
                question.Answer = checkBox.Checked;
            if (checkBox1.Checked == true)
                question.Answer1 = checkBox1.Checked;
            if (checkBox2.Checked == true)
                question.Answer2 = checkBox2.Checked;

            String data = JsonSerializer.Serialize<QuestionLogicMultipleMultiple>(question);

            MySqlCommand query = new MySqlCommand("INSERT INTO question(id, test_id, text, type, data) VALUES (NULL, @id, @LogicQuestion, @TypicalQuestion, @data);", con.getConnection());
            query.Parameters.AddWithValue("@id", test.id);
            query.Parameters.AddWithValue("@LogicQuestion", LogicQuestion);
            query.Parameters.AddWithValue("@TypicalQuestion", TypicalQuestion);
            query.Parameters.AddWithValue("@data", data);
            System.Diagnostics.Debug.WriteLine(query);
            System.Diagnostics.Debug.WriteLine(test.id);


            UInt64 questiId = (UInt64)con.ExecuteNonQuery(query);
            Question questi = new Question(questiId, test.id, LogicQuestion, TypicalQuestion, data);
        }

        void questionLogicConformity()
        {
            String LogicQuestion = text_Box.Text;
            String TypicalQuestion = tp_Box.Text;

            QuestionLogicConformity question = new QuestionLogicConformity();

            question.Text_Box_1 = text_Box1.Text;
            question.Text_Box_2 = text_Box2.Text;

            question.Text_Box_a = text_Box_a.Text;
            question.Text_Box_b = text_Box_b.Text;

            question.Return_Box_1 = return_Box1.Text;
            question.Return_Box_2 = return_Box2.Text;

            String data = JsonSerializer.Serialize<QuestionLogicConformity>(question);

            MySqlCommand query = new MySqlCommand("INSERT INTO question(id, test_id, text, type, data) VALUES (NULL, @id, @LogicQuestion, @TypicalQuestion, @data);", con.getConnection());
            query.Parameters.AddWithValue("@id", test.id);
            query.Parameters.AddWithValue("@LogicQuestion", LogicQuestion);
            query.Parameters.AddWithValue("@TypicalQuestion", TypicalQuestion);
            query.Parameters.AddWithValue("@data", data);
            System.Diagnostics.Debug.WriteLine(query);
            System.Diagnostics.Debug.WriteLine(test.id);


            UInt64 questiId = (UInt64)con.ExecuteNonQuery(query);
            Question questi = new Question(questiId, test.id, LogicQuestion, TypicalQuestion, data);
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
            text_Box.Text = null;
            textBox.Text = null;
            textBox1.Text = null;
            lots_textBox.Text = null;
            lots_textBox1.Text = null;
            lots_textBox2.Text = null;
            word_Box.Text = null;
            text_Box1.Text = null;
            text_Box2.Text = null;
            text_Box_a.Text = null;
            text_Box_b.Text = null;
            return_Box1.Text = null;
            return_Box2.Text = null;
            tp_Box.Text = null;
            true_radioButton.Checked = false;
            false_radioButton.Checked = false;
            radioButton.Checked = false;
            radioButton1.Checked = false;
            checkBox.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_Box.SelectedIndex == 0) {
                groupBox();
                groupBox1.BringToFront();
                groupBox1.Visible = true;
            }

            else if (tp_Box.SelectedIndex == 1) {
                groupBox();
                groupBox2.BringToFront();
                groupBox2.Visible = true;
            }

            else if (tp_Box.SelectedIndex == 2) {
                groupBox();
                groupBox3.BringToFront();
                groupBox3.Visible = true;
            }

            else if (tp_Box.SelectedIndex == 3) {
                groupBox();
                groupBox4.BringToFront();
                groupBox4.Visible = true;
            }

            else if (tp_Box.SelectedIndex == 4) {
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

            if(test == null)
            {
                string nameTest = nameTest_Box.Text;

                User user = Program.GetUser();

                string tests = "INSERT INTO tests(name, user_id) VALUES ('" + nameTest + "','" + user.id + "');";
                System.Diagnostics.Debug.WriteLine(tests);

                UInt64 id = Convert.ToUInt64(con.ExecuteNonQuery(tests));
                test = new Test(id, nameTest, user.id);
            }
            // Прада / Лошь
            if (tp_Box.SelectedIndex == 0)
            {
                questionLogic();
            }
            // Несколько вариантов и один ответ
            if (tp_Box.SelectedIndex == 1)
            {
                questionLogicMultipleOne();
            }
            // Несколько вариантов и несколько ответов
            if (tp_Box.SelectedIndex == 2)
            {
                questionLogicMultipleMultiple();
            }
            // Ввод слова
            if (tp_Box.SelectedIndex == 3)
            {
                questionLogicText();
            }
            if (tp_Box.SelectedIndex == 4)
            {
                questionLogicConformity();
            }



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


        }

        public void button2_Click(object sender, EventArgs e)
        {


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

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void text_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameTest_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
