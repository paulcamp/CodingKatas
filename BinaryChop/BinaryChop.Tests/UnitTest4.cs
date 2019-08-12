
using NUnit.Framework;

namespace BinaryChop.Tests
{
    [TestFixture]
    public class UnitTest4
    {
        [TestCase(new[] { 1, 3, 5 }, 1, 0)]
        [TestCase(new[] { 1, 3, 5 }, 3, 1)]
        [TestCase(new[] { 1, 3, 5 }, 5, 2)]
        [TestCase(new[] { 1, 3, 5, 7, 9, 10, 11, 12, 15, 18 }, 11, 6)]
        public void HappyPath(int[] sortedArray, int numberToFind, int position)
        {
            var result = new BinaryChop4().BinarySearch(sortedArray, numberToFind);

            Assert.AreEqual(position, result);


        }


        [TestCase(new[] { 1, 3, 5 }, 6, -999)]
        [TestCase(new[] { 1, 3, 5 }, 4, -999)]
        [TestCase(new[] { 1, 3, 5 }, 0, -999)]
        [TestCase(new[] { 1, 3, 5, 7, 9, 10, 11, 12, 15, 18 }, 13, -999)]
        public void SadPath(int[] sortedArray, int numberToFind, int position)
        {
            var result = new BinaryChop4().BinarySearch(sortedArray, numberToFind);

            Assert.AreEqual(position, result);


        }
    }
}
