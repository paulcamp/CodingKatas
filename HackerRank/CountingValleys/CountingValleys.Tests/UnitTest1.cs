using CountingValleys;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(8, "UDDDUDUU", 1)]
        [TestCase(12, "DDUUDDUDUUUD", 2)]
        public void Test1(int size, string input, int expected)
        {
            var result =  Program.countingValleys(size, input);

            Assert.AreEqual(expected, result);
        }
    }
}