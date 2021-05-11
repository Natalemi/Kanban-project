using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban_project
{
    class Test
    {
        public UInt64 id;
        public string name;
        public UInt64 user_id;

        public Test(UInt64 id, string name, UInt64 user_id)
        {
            this.id = id;
            this.name = name;
            this.user_id = user_id;
        }
    }
}
