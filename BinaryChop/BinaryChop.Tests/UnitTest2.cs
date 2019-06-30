
using NUnit.Framework;

namespace BinaryChop.Tests
{
    [TestFixture]
    public class UnitTest2
    {
        [TestCase(-1, 3, new int[0])]
        [TestCase(-1, 3, new[] { 1 })]
        [TestCase(0, 1, new[] { 1 })]
        [TestCase(0, 1, new[] { 1, 3, 5 })]
        [TestCase(1, 3, new[] { 1, 3, 5 })]
        [TestCase(2, 5, new[] { 1, 3, 5 })]
        [TestCase(-1, 0, new[] { 1, 3, 5 })]
        [TestCase(-1, 2, new[] { 1, 3, 5 })]
        [TestCase(-1, 4, new[] { 1, 3, 5 })]
        [TestCase(-1, 6, new[] { 1, 3, 5 })]
        [TestCase(0, 1, new[] { 1, 3, 5, 7 })]
        [TestCase(1, 3, new[] { 1, 3, 5, 7 })]
        [TestCase(2, 5, new[] { 1, 3, 5, 7 })]
        [TestCase(3, 7, new[] { 1, 3, 5, 7 })]
        [TestCase(-1, 0, new[] { 1, 3, 5, 7 })]
        [TestCase(-1, 2, new[] { 1, 3, 5, 7 })]
        [TestCase(-1, 4, new[] { 1, 3, 5, 7 })]
        [TestCase(-1, 6, new[] { 1, 3, 5, 7 })]
        [TestCase(-1, 8, new[] { 1, 3, 5, 7 })]
        public void TestMethod1(int result, int find, int[] array)
        {
            var Chop1 = new BinaryChop2();

            Assert.AreEqual(result, Chop1.Chop(find, array));
        }
    }
}
