using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "server=127.0.0.1;port=3306;database=testdb;uid=test;pwd=test;";
            using (var conn = new MySqlConnection(connstr))
            {
                conn.Open();
                var begin_time = DateTime.Now.AddMinutes(-10);
                var end_time = DateTime.Now;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select @@hostname";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(1));
                            break;
                        }
                    }
                }
            }
        }
    }
}
