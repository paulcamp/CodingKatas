using System;

namespace SolidExamples
{
    public class SingleResp
    {
        //easier to understand
        //easier to maintain
        //easier to reuse

        public class DataAccess
        {
            public static void InsertData()
            {
                DoDatabaseInsert();
                Console.WriteLine("Data inserted into database successfully at time:" +
                                  DateTime.UtcNow.ToLongDateString());
            }
            
            private static void DoDatabaseInsert()
            {
                //placeholder
            }
        }

        //problem above is that "logging" responsibility may need to shift from console to file, or event viewer, etc.
        //extract into separate classes

        public class DataAccessSolid
        {
            public static void InsertData()
            {
                DoDatabaseInsert();
            }

            private static void DoDatabaseInsert()
            {
                //placeholder
            }
        }
        
        public class LoggerSolid
        {
            public static void WriteLog()
            {
                Console.WriteLine("Data inserted into database successfully at time:" +
                                  DateTime.UtcNow.ToLongDateString());
            }
        }

    }
}
