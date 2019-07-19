using System;
using System.Linq;

namespace LuhnTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            //TODO: allow command line stdout based running

            Console.Write("Luhn Check of 49927398716, result "); Console.Write(LuhnCheck("49927398716") == true ? "Valid" : "Invalid"); Console.WriteLine();
            Console.Write("Luhn Check of 49927398717, result "); Console.Write(LuhnCheck("49927398717") == true ? "Valid" : "Invalid"); Console.WriteLine();
            Console.Write("Luhn Check of 1234567812345678, result "); Console.Write(LuhnCheck("1234567812345678") == true ? "Valid" : "Invalid"); Console.WriteLine();
            Console.Write("Luhn Check of 1234567812345670, result "); Console.Write(LuhnCheck("1234567812345670") == true ? "Valid" : "Invalid"); Console.WriteLine();
            Console.ReadKey();  
        }


        static bool LuhnCheck(string cardDigits)
        {
            string reversed = Reverse(cardDigits);

            int[] numbers = reversed.Select(c => c - '0').ToArray();

            bool oddState = true;
            int len = numbers.Length;
            int index = 0;
            int s1 = 0;
            int s2 = 0;

            do
            {
                if(oddState)
                {
                    s1 += numbers[index];
                }
                else
                {
                    var partialS2 = numbers[index] * 2;

                    if (partialS2 > 9)
                        partialS2 = partialS2 - 9; //same as adding each digit (eg 12 => 1+2 = 3, same as 12 - 9)

                    s2 += partialS2;
                }

                oddState = !oddState;
                index++;

            } while (index < len);

            
            var sum = s1 + s2;

            if (sum % 10 == 0)
                return true;

            return false;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
              
    }
}
