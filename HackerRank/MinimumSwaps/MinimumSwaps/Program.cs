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

            var originals = Enumerable.Range(0, input.Length).ToArray();
            Array.Sort(input, originals);

            //assumes positive sequential values
            //marks processed swaps with -1
            //swap with non intersecting cycles

            int swaps = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentValue = originals[i];
                if (currentValue < 0) continue;
                while (currentValue != i)
                {
                    //make a swap 
                    int newValue = originals[currentValue];
                    //dont actually swap, just mark what i would have swapped with as processed
                    originals[currentValue] = -1; 
                    currentValue = newValue;
                    swaps++;
                }
                originals[i] = -1; //mark as processed
            }
            return swaps;
        }

        //if restricted to adjacent swaps, do a bubble sort
        public  static long MinimumSwapsAdjacentOnly(int[] input)
        {
            var swapsMade = 0;
            var length = input.Length;
            var temp = input[0];

            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (input[i] > input[j])
                    {
                        temp = input[i];
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
