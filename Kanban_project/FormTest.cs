using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kanban_project
{
    public partial class FormTest : Form
    {
        Conection con;

        List<Question> questions;
        int QuestionCounter;
        int Counter;

        public FormTest()
        {
            InitializeComponent();
            con = new Conection();
            con.Open();
        }

        int groupBox()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;

            return 0;
        }

        void cleareTextBox()
        {
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
            true_radioButton.Checked = false;
            false_radioButton.Checked = false;
            radioButton.Checked = false;
            radioButton1.Checked = false;
            checkBox.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        public void CheckQuestion()
        {
            Question question = this.questions[QuestionCounter];
            QuestionCounter++;
            if (question.type == "Множество вариантов и несколько ответов")
            {
                QuestionLogicMultipleMultiple questionLogicMultipleMultiple = JsonSerializer.Deserialize<QuestionLogicMultipleMultiple>(question.data);
                if (questionLogicMultipleMultiple.Answer == checkBox.Checked)
                {
                    if (questionLogicMultipleMultiple.Answer1 == checkBox1.Checked)
                    {
                        if (questionLogicMultipleMultiple.Answer2 == checkBox2.Checked)
                        {
                            Counter++;
                        }
                    }
                }
            }
            if (question.type == "Истина/Ложь")
            {
                QuestionLogic questionLogic = JsonSerializer.Deserialize<QuestionLogic>(question.data);
                if (questionLogic.CorrectAnswer == true_radioButton.Checked)
                {
                    Counter++;
                }
            }

            if (question.type == "Несколько вариантов и один ответ")
            {
                QuestionLogicTextMultipleOne questionLogicTextMultipleOne = JsonSerializer.Deserialize<QuestionLogicTextMultipleOne>(question.data);
                if (questionLogicTextMultipleOne.CorrectAnswer == radioButton.Checked)
                {
                    Counter++;
                }
            }
            if (question.type == "Ввод слова")
            {
                QuestionLogicText questionLogicText = JsonSerializer.Deserialize<QuestionLogicText>(question.data);
                if (questionLogicText.CorrectAnswer == word_Box.Text)
                {
                    Counter++;
                }
            }
            if (question.type == "На соответствие")
            {
                QuestionLogicConformity questionLogicConformity = JsonSerializer.Deserialize<QuestionLogicConformity>(question.data);
                if (questionLogicConformity.Return_Box_1 == return_Box1.Text)
                {
                    if (questionLogicConformity.Return_Box_2 == return_Box2.Text)
                    {
                        Counter++;
                    }
                }
            }
            
        }

        public void ShowQuestions()
        {

            while (QuestionCounter < this.questions.Count)
            {
                Question question = this.questions[QuestionCounter];
                
                if (question.type == "Истина/Ложь")
                {
                    label4.Text = question.text;
                    QuestionLogic questionLogic = JsonSerializer.Deserialize<QuestionLogic>(question.data);
                    groupBox();
                    groupBox1.BringToFront();
                    groupBox1.Visible = true;

                    true_radioButton.Text = questionLogic.TrueAnswer;
                    false_radioButton.Text = questionLogic.FalseAnswer;
                    return ;//выводим все что надо

                }
                if (question.type == "Несколько вариантов и один ответ")
                {
                    label4.Text = question.text;
                    QuestionLogicTextMultipleOne questionLogic = JsonSerializer.Deserialize<QuestionLogicTextMultipleOne>(question.data);
                    groupBox();
                    groupBox2.BringToFront();
                    groupBox2.Visible = true;

                    textBox.Text = questionLogic.TrueAnswer;
                    textBox1.Text = questionLogic.FalseAnswer;

                    return;//выводим все что надо
                }
                if (question.type == "Множество вариантов и несколько ответов")
                {
                    label4.Text = question.text;
                    QuestionLogicMultipleMultiple questionLogic = JsonSerializer.Deserialize<QuestionLogicMultipleMultiple>(question.data);
                    groupBox();
                    groupBox3.BringToFront();
                    groupBox3.Visible = true;
                    lots_textBox.Text = questionLogic.Text;
                    lots_textBox1.Text = questionLogic.Text1;
                    lots_textBox2.Text = questionLogic.Text2;

                    
                    return ; //выводим все что надо
                }
                if (question.type == "Ввод слова")
                {
                    label4.Text = question.text;
                    QuestionLogicText questionLogic = JsonSerializer.Deserialize<QuestionLogicText>(question.data);
                    groupBox();
                    groupBox4.BringToFront();
                    groupBox4.Visible = true;

                    
                    return ;//выводим все что надо
                }
                if (question.type == "На соответствие")
                {
                    label4.Text = question.text;
                    QuestionLogicConformity questionLogic = JsonSerializer.Deserialize<QuestionLogicConformity>(question.data);
                    groupBox();
                    groupBox5.BringToFront();
                    groupBox5.Visible = true;
                    text_Box1.Text = questionLogic.Text_Box_1;
                    text_Box2.Text = questionLogic.Text_Box_2;
                    text_Box_a.Text = questionLogic.Text_Box_a;
                    text_Box_b.Text = questionLogic.Text_Box_b;


                    return;//выводим все что надо
                }
            }
            // Вывести кколличесиво очков скколькко пользователь набрал
            MessageBox.Show("Ваш бал = " + Convert.ToString(Counter));
            string name = Program.user.name;
            UInt64 ball = Convert.ToUInt64(Counter);
            MySqlCommand query = new MySqlCommand("INSERT INTO tab(name, ball) VALUES (@name, @ball);", con.getConnection());
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@ball", ball);
            con.ExecuteNonQuery(query);

            // перевести на главную страницу
            if (Program.user.teacher == true)
            {
                FormTeacher form = new FormTeacher();
                this.Hide();
                form.Show();
            }
            if(Program.user.teacher == false)
            {
                FormPupil form = new FormPupil();
                this.Hide();
                form.Show();
            }
            
            // очки будут в Counter
        }

        public void GetQuestions()
        {
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM question WHERE test_id = '" + Program.ActiveTest.id + "' ORDER BY id;", con.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                this.questions = new List<Question>();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    UInt64 id = Convert.ToUInt64(table.Rows[i].Field<UInt64>("id"));
                    string text = (table.Rows[i].Field<string>("text"));
                    string type = table.Rows[i].Field<string>("type");
                    string data = table.Rows[i].Field<string>("data");

                    Question question = new Question(id, Program.ActiveTest.id, text, type, data);

                    this.questions.Add(question);
                }
            }
            else
            {
                MessageBox.Show("ошибка");
            }
        }

        public void FormTest_Load(object sender, EventArgs e)
        {
            FormTesting f = new FormTesting();
            this.label1.Text = f.Ids();

            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM tests WHERE id = '" + Program.testId + "' LIMIT 1;", con.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine(table.Rows[0]["id"]);
                UInt64 id = Convert.ToUInt64(table.Rows[0].Field<long>("id"));
                
                string name = table.Rows[0].Field<string>("name");
                UInt64 user_id = Convert.ToUInt64(table.Rows[0].Field<string>("user_id"));

                label1.Text = name;
                Test test = new Test(id, name, user_id);
                Program.ActiveTest = test;
                GetQuestions();
            }
            else
            {
                MessageBox.Show("ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            CheckQuestion();
            ShowQuestions();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            cleareTextBox();
            button1.Visible = false;
            button3.Visible = true;


            ShowQuestions();
        }
    }
}
