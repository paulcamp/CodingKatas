using System;
using System.Collections.Generic;

namespace Fizzbuzz
{
    /*
     * Write a program that prints the numbers from 1 to n. (usually 100)
     * But for multiples of three print “Fizz” instead of the number 
     * and for the multiples of five print “Buzz”. 
     * For numbers which are multiples of both three and five print “FizzBuzz”.
     * */

    public class Program
    {
        static void Main(string[] args)
        {
            int iterations = 100;

            if (args.Length == 1)
                iterations = Convert.ToInt32(args[0]);

            //allow unit test
            List<string> output = doFizzBuzz(iterations);

            foreach(var line in output)
            {
                Console.WriteLine(line);
            }

        }

        public static List<string> doFizzBuzz(int iterations)
        {
            var results = new List<string>();
            for (int i=1; i<iterations+1; i++)
            {
                string text = null;

                if (i % 3 == 0)
                    text += "Fizz";

                if (i % 5 == 0)
                    text += "Buzz";

                results.Add(text ?? i.ToString());

            }


            return results;
        }

    }
}
