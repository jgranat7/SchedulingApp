using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SchedulingApp.DAL
{
    public class DBHelper
    {
        private static string connectionString = "server=localhost;port=3306;database=client_schedule;user=test;password=test";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}