using System.Linq;
using NUnit.Framework;
using Rotate;

namespace Tests
{
    public class Tests
    {
        //rotate input list by n rotations, return index of max element after rotations

        [SetUp]
        public void Setup()
        {
        }

        //simple case
        [TestCase(new []{1,2,3},  new[]{1,2,6},  new[]{1,0,2})]
        //simple, rotate not necessary
        [TestCase(new[] { 1, 2, 3,4,5,6,7,8,9,10,11,12,13,14,15,16 }, new[] { 16 }, new[] { 15 })]
        //large number of rotations
        [TestCase(new[] { 1,2,3,4,5,6,7,8,9,10,11,12,14,14,15,16 }, new[] { 1000000001 }, new[] { 14 })]
        //even bigger number of rotations to see performance time
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 14, 15, 16 }, new[] { 1000000000, 2000000001 }, new[] { 15,14 })]
        public void TestSuite(int[] input, int[] rotations, int[] expected)
        {
            var results = Program.getMaxElementIndexes(input.ToList(), rotations.ToList());

            Assert.AreEqual(expected.ToList(), results);
        }

    }
}