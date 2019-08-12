namespace BinaryChop
{
    public class BinaryChop4
    {
        public int BinarySearch(int[] sortedArray, int numberToFind)
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            int middle = 0;

            while (low <= high)
            {
                middle = (low + high) / 2;
                if (sortedArray[middle] > numberToFind)
                    high = middle - 1;
                else if (sortedArray[middle] < numberToFind)
                    low = middle + 1;
                else
                {
                    return middle;
                }

            }

            return -999; //not found
        }
    }
}
