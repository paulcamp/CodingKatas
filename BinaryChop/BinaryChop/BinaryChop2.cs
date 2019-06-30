namespace BinaryChop
{
    public class BinaryChop2
    {
        //chop(int, array_of_int)  -> int
        public int Chop(int numberToFind, int[] sortedArray)
        {
            
            int len = sortedArray.Length;

            if (len == 0)
                return -1;

            int lowerBounds = 0;
            int upperBounds = len-1;
            int iterations = 0;

            var seek = (upperBounds - lowerBounds) / 2;
            do
            {

                var number = sortedArray[seek];

                if (number == numberToFind)
                    return seek;

                //safeguard
                iterations++;

                if (iterations > len)
                    return -1;

                if (number < numberToFind)
                {
                    lowerBounds = seek;

                    var diff = (upperBounds - seek);

                    seek =  lowerBounds + (diff  / 2); //need to add lowerbounds

                    if (diff % 2 != 0)
                        seek ++;  //need to go higher if there is a remainder

                    continue;
                }
                if(number > numberToFind)
                {
                   
                    upperBounds = seek;

                    var diff = (seek - lowerBounds);

                    seek = diff / 2; //will naturally go lower as the remainder is ignored
                  
                    continue;
                }
                

            } while (true);
            

           
        }
    }
}
