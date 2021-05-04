using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban_project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public User user;
        static public User GetUser()
        {
            return user;
        }
        static public void InstalUser(User us)
        {
            user = us;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}