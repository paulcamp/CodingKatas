namespace BinaryChop.Tests
{
    public class BinaryChop3
    {

        private int recurse(int numberToFind, int lowerBounds, int upperBounds, int seek, int iteration, int[] sortedArray)
        {

            int len = sortedArray.Length;
            var number = sortedArray[seek];

            if (number == numberToFind)
                return seek;

            if (iteration > len)
                return -1;

            if (number < numberToFind)
            {
                lowerBounds = seek;

                var diff = (upperBounds - seek);

                seek = lowerBounds + (diff / 2); //need to add lowerbounds

                if (diff % 2 != 0)
                    seek++;  //need to go higher if there is a remainder

                return recurse(numberToFind, lowerBounds, upperBounds, seek, ++iteration, sortedArray);
            }
            if (number > numberToFind)
            {

                upperBounds = seek;

                var diff = (seek - lowerBounds);

                seek = diff / 2; //will naturally go lower as the remainder is ignored

                return recurse(numberToFind, lowerBounds, upperBounds, seek, ++iteration, sortedArray);

            }
            return -1;
        }

        //chop(int, array_of_int)  -> int
        public int Chop(int numberToFind, int[] sortedArray)
        {

            int len = sortedArray.Length;

            if (len == 0)
                return -1;

            int lowerBounds = 0;
            int upperBounds = len - 1;
            
            var seek = (upperBounds - lowerBounds) / 2;

            //now call recursive
            return recurse(numberToFind, lowerBounds, upperBounds, seek, 0, sortedArray);



        }
    }
}
