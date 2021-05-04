using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Kanban_project
{
    class Conection
    {
        static string host = "localhost";
        static string database = "kanban_project";
        static string userDB = "root";
        static string password = "root";
        MySqlConnection strProvider = new MySqlConnection ("server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password);
        public void Open()
        {
            if (strProvider.State == System.Data.ConnectionState.Closed)
                strProvider.Open();
        }
        public void Close()
        {
            if (strProvider.State == System.Data.ConnectionState.Open)
                strProvider.Close();
        }
 
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = strProvider.BeginTransaction();
                MySqlCommand cmd = strProvider.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
        public MySqlConnection getConnection()
        {
            return strProvider;
        }

    }
}
