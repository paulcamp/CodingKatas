using System;
using System.Linq;

namespace MinimumSwaps
{
    public class Program
    {
        static void Main(string[] args)
        {
            //You need to find the minimum number of swaps required to sort the array in ascending order.
        }

        public static int MinimumSwaps(int[] input)
        {
            //store relative index positions of original
            var indexPositions = Enumerable.Range(0, input.Length).ToArray();
            Array.Sort(input, indexPositions);
            
            //cycle through the index positions in order and mark each potential swap

            int swaps = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentValue = indexPositions[i];
                if (currentValue < 0) continue; //already processed
                while (currentValue != i) //not in sequence?
                {
                    int temp = indexPositions[currentValue]; //cycle
                    indexPositions[currentValue] = -1; //mark it as processed
                    currentValue = temp; //ready for next while comparison
                    swaps++;
                }
                indexPositions[i] = -1; //mark as processed
            }
            return swaps;
        }

        //if restricted to adjacent swaps, do a bubble sort
        public  static long MinimumSwapsAdjacentOnly(int[] input)
        {
            var swapsMade = 0;
            var length = input.Length;
           
            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (input[i] > input[j])
                    {
                        var temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                        swapsMade++;
                    }
                }
            }

            return swapsMade;
        }
    }
}
