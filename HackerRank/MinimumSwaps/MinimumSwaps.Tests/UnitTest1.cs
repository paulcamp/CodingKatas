using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] { 8,7,6,5,4,3,2,1}, 4)]
        [TestCase(new[] { 1, 3, 5, 2, 4, 6, 7 }, 3)]
        public void TestSuite(int[] input, int expected)
        {
            var result = MinimumSwaps.Program.MinimumSwaps(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new[] { 8, 7, 6, 5, 4, 3, 2, 1 }, 28)]
        [TestCase(new[] { 1, 3, 5, 2, 4, 6, 7 }, 3)]
        public void TestSuite_Adjacent_Restriction(int[] input, int expected)
        {
            var result = MinimumSwaps.Program.MinimumSwapsAdjacentOnly(input);

            Assert.AreEqual(expected, result);
        }
    }
}