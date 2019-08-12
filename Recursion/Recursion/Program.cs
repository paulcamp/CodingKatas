using System;

namespace Recursion
{
    class Program
    {
        //using recursion, print out the fibonacci sequence
        static void Main(string[] args)
        {
            //set an upper limit so we dont overflow!
            int upperLimit = 2000;
            //set the first 2 numbers in the sequence
            int seed1 = 0;
            int seed2 = 1;

            string result = doFibonacci(seed1, seed2, upperLimit);

            Console.WriteLine(result);

        }

        private static string doFibonacci(int seed1, int seed2, int upperLimit)
        {
            int result = seed1 + seed2;

            //the exist condition
            if (result > upperLimit)
                return "";

            return result.ToString() + "," + doFibonacci(seed2, result, upperLimit);
            
        }
    }
}
