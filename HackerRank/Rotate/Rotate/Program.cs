using System.Collections.Generic;
using System.Linq;


namespace Rotate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //left rotate the array puzzle, with some additional output:
            //for a given array, rotate left by given number of rotations, then record teh index of the maximum element after the rotation.
            
            //Followup reading: can we do something similar to ROT encryption to achieve this with optimal performance?
        }

        public static List<int> getMaxElementIndexes(List<int> a, List<int> rotate)
        {
            var maximumIndices = new List<int>();
            var arrayed = a.ToArray();
            
            foreach (var rotateCount in rotate)
            {
                var rotatedList = DoRotation(arrayed, rotateCount);
                
                //get the index of max value and add to the results
                int maxValue = rotatedList.Max();
                var maxIndex = rotatedList.IndexOf(maxValue);

                maximumIndices.Add(maxIndex);
            }

            return maximumIndices;
        }

        private static List<int> DoRotation(int[] source, int leftRotations)
        {

            //optimisation 1 - if rotation count is same as size of items, dont do anything
            if (source.Length == leftRotations)
            {
                return source.ToList();
            }

            //optimisation 2 - only rotate by the remainder
            var remainder = (leftRotations % source.Length);
            var numberOfRotations = remainder;

            //copy the source list so we don't mutate it
            //use queue to improve performance
            var queue = new Queue<int>(source);
            
            for (int i = 0; i < numberOfRotations; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            return queue.ToList();
        }
    }
}
