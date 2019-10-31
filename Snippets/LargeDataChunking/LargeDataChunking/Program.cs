using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace LargeDataChunking
{
    class Program
    {
        static void Main(string[] args)
        {
            //stream large data table out to file
            StreamWriter sw = new StreamWriter(@"d:\somedatafile.txt");

            foreach (var block in GetData())
            {
                sw.WriteLine(block);
            }

            sw.Close();
        }


        public static  IEnumerable<string> GetData()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Main;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"Select Id from dbo.YOURTABLE";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string foo = reader.GetGuid(0).ToString();
                            yield return foo;
                    }
                }
            }
        }

    }
}
