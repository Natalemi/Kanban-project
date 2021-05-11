using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_project
{
    class Question
    {
        public UInt64 id;
        public UInt64 test_id; // связь с тестом
        public string text;
        public string type;
        public string data; // в єтом поле храним данные самого вопроса в текстовом формате

        public Question(UInt64 id, UInt64 test_id, string text, string type, string data)
        {
            this.id = id;
            this.test_id = test_id;
            this.text = text;
            this.type = type;
            this.data = data;
        }
    }
}
