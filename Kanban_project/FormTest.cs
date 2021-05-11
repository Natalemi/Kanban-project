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
        List<Question> questions;
        int QuestionCounter;
        int Counter;
        
        public FormTest()
        {
            InitializeComponent();
            
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

        public void CheckQuestion()
        {
            Question question = this.questions[QuestionCounter];

        }
        public void ShowQuestions()
        {

            while (QuestionCounter < this.questions.Count)
            {
                Question question = this.questions[QuestionCounter];
                QuestionCounter++;
                label4.Text = question.text;
                if (question.type == "Истина/Ложь")
                {
                    
                    QuestionLogic questionLogic = JsonSerializer.Deserialize<QuestionLogic>(question.data);
                    groupBox();
                    groupBox1.BringToFront();
                    groupBox1.Visible = true;
                    if (question.type == "Истина/Ложь")
                    {
                        questionLogic.TrueAnswer = true_radioButton.Text;
                        questionLogic.FalseAnswer = false_radioButton.Text;
                        if (true_radioButton.Checked == questionLogic.CorrectAnswer)
                        {
                                                   
                            Counter++;
                            MessageBox.Show("+ 1 бал");
                        


                        }


                    }

                    return;//выводим все что надо
                }
                if (question.type == "Несколько вариантов и один ответ")
                {
                    QuestionLogicTextMultipleOne questionLogic = JsonSerializer.Deserialize<QuestionLogicTextMultipleOne>(question.data);
                    groupBox();
                    groupBox2.BringToFront();
                    groupBox2.Visible = true;
                    // questionLogic.CorrectAnswer;

                    return;//выводим все что надо
                }
                if (question.type == "Множество вариантов и несколько ответов")
                {
                    QuestionLogicMultipleMultiple questionLogic = JsonSerializer.Deserialize<QuestionLogicMultipleMultiple>(question.data);
                    groupBox();
                    groupBox3.BringToFront();
                    groupBox3.Visible = true;
                    // questionLogic.CorrectAnswer;

                    return;//выводим все что надо
                }
                if (question.type == "Ввод слова")
                {
                    QuestionLogicText questionLogic = JsonSerializer.Deserialize<QuestionLogicText>(question.data);
                    groupBox();
                    groupBox4.BringToFront();
                    groupBox4.Visible = true;
                    // questionLogic.CorrectAnswer;

                    return;//выводим все что надо
                }
                if (question.type == "На соответствие")
                {
                    QuestionLogicConformity questionLogic = JsonSerializer.Deserialize<QuestionLogicConformity>(question.data);
                    groupBox();
                    groupBox5.BringToFront();
                    groupBox5.Visible = true;
                    // questionLogic.CorrectAnswer;

                    return;//выводим все что надо
                }

            }
            // Вывести кколличесиво очков скколькко пользователь набрал
            // перевести на главную страницу
            // очки будут в Counter
        }

        public void GetQuestions()
        {
            Conection con = new Conection();
            con.Open();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM question WHERE test_id = '" + Program.ActiveTest.id + "';", con.getConnection());

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
            button1.Visible = false;
            button3.Visible = true;
            CheckQuestion();

            ShowQuestions();
        }
    }
}
