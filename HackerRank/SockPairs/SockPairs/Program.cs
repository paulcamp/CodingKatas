using System;
using System.Collections.Generic;

namespace SockPairs
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
                ;
            int result = sockMerchant(n, ar);
           
        }

        //Given an array of integers representing the color of each sock, determine how many pairs of socks with matching colors there are.

        public static int sockMerchant(int n, int[] ar)
        {
            Dictionary<int, int> uniques = new Dictionary<int, int>();
            int runningTotalPairs = 0;

            foreach (var i in ar)
            {
                if (uniques.ContainsKey(i))
                {
                    uniques[i] ++;
                    if (uniques[i] % 2 == 0)
                    {
                        runningTotalPairs++;
                        uniques.Remove(i);
                    }
                }
                else
                {
                    uniques.Add(i,1);
                }
            }
            
            return runningTotalPairs;
        }
    }
}
