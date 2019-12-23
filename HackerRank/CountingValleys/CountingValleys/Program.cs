using System;

namespace CountingValleys
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

          
        }

        public static int countingValleys(int n, string s)
        {
            //count every drop below 0
            //UDUUDDDU

            int altitude = 0;
            int previousAltitude = 0;
            int valleysEntered = 0;

            foreach (var c in s.ToUpper())
            {
                if (c == 'U')
                {
                    altitude++;
                }
                else if (c == 'D')
                {
                    altitude--;

                    if (previousAltitude >= 0 && altitude < 0)
                    {
                        valleysEntered++;
                    }
                }

                previousAltitude = altitude;
            }

            
            return valleysEntered;
        }
    }
}
