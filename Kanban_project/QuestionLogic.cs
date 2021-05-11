using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Kanban_project
{
    class QuestionLogic
    {
        public string TrueAnswer { get; set; }
        public string FalseAnswer { get; set; }
        public bool CorrectAnswer { get; set; }
    }

    class QuestionLogicText
    {
        public string CorrectAnswer { get; set; }
    }

    class QuestionLogicTextMultipleOne
    {
        public string TrueAnswer { get; set; }
        public string FalseAnswer { get; set; }
        public bool CorrectAnswer { get; set; }
    }

    class QuestionLogicMultipleMultiple
    {
        public string Text { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }

        public bool Answer { get; set; }
        public bool Answer1 { get; set; }
        public bool Answer2 { get; set; }

    }

    class QuestionLogicConformity
    {
        public string Text_Box_1 { get; set; }
        public string Text_Box_2 { get; set; }

        public string Text_Box_a { get; set; }
        public string Text_Box_b { get; set; }

        public string Return_Box_1 { get; set; }
        public string Return_Box_2 { get; set; }
    }
}
