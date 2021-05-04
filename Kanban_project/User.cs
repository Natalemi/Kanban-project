using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_project
{
    class User
    {
        public UInt64 id;
        public string email;
        public string password;
        public string name;
        public bool teacher;

        public User(UInt64 id, string email, string password, string name, bool teacher)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.name = name;
            this.teacher = teacher;
        }
    }

}
