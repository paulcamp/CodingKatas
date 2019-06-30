using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChop
{
    public class BinaryChop1
    {
        //chop(int, array_of_int)  -> int
        public int Chop(int numberToFind, int[] sortedArray)
        {
            
            int len = sortedArray.Length;

            if (len == 0)
                return -1;

            int seekPosition = len / 2;
            int previousSeekPosition = len;
            bool found = false;
            int iterations = 0;

            do
            {
                if (iterations > len)
                    break;

                iterations++;


                int number = sortedArray[seekPosition];

                if(number < numberToFind)
                {
                    int newSeekPosition = (previousSeekPosition + seekPosition) / 2;
                    previousSeekPosition = seekPosition;
                    seekPosition = newSeekPosition;
                    continue;
                }

                if(number > numberToFind)
                {
                    int newSeekPosition = (previousSeekPosition - seekPosition) / 2;
                    previousSeekPosition = seekPosition;
                    seekPosition = newSeekPosition;
                    continue;
                }

                if (number == numberToFind)
                    found = true;

            }while(found == false);

            if (found)
                return seekPosition;


            return -1;
        }


    }
}
