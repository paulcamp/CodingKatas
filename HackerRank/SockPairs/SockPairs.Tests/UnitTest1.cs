using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(6, new[] {1,2,1,2,1,2}, 2)]
        [TestCase(9, new[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 }, 3)]
        public void TestSuite(int arraySize, int[] inputArray, int expectedPairs)
        {
            var result = SockPairs.Program.sockMerchant(arraySize, inputArray);

            Assert.AreEqual(expectedPairs, result);
        }
    }
}