using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MoreLinq;

namespace LargeDataChunking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Option1 (uncomment)
            //GetAllData(); //922Mb about 1 minute

            //Option2
            //stream large data table out to file
            StreamWriter sw = new StreamWriter(@"d:\some-streamed-datafile.txt");

            foreach (var batch in StreamData().Batch(1000))
            {
                sw.WriteLine(batch);
            }

            sw.Close();
        }

        public static void GetAllData()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Main;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [PerkId]
      ,[StudentId]
      ,[Site]
      ,[UsedOn]
      ,[UsedOnHour]
      ,[UsedOnDay]
      ,[InferredUse]
  FROM [Main].[dbo].[YOURTABLE] ORDER BY UsedOn";

                var sda = new SqlDataAdapter(cmd);
                var dataSet = new DataSet();
                var numResults = sda.Fill(dataSet);


                StreamWriter sw = new StreamWriter(@"d:\some-big-datafile.txt");
                dataSet.WriteXml(sw);
                sw.Close();
            
            }
        }


        public static  IEnumerable<string> StreamData()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Main;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [PerkId]
      ,[StudentId]
      ,[Site]
      ,[UsedOn]
      ,[UsedOnHour]
      ,[UsedOnDay]
      ,[InferredUse]
  FROM [Main].[dbo].[YOURTABLE] ORDER BY UsedOn";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string foo = reader.GetGuid(0).ToString();
                        string bar = reader.GetGuid(1).ToString();
                        string cat = reader.GetString(2);
                        yield return foo + '|' + bar + '|' + cat;
                    }
                }
            }
        }

    }
}
