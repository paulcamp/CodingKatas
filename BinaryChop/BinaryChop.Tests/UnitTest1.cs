using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryChop;

namespace BinaryChop.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTheChop()
        {
            var Chop1 = new BinaryChop1();

            Assert.AreEqual(-1, Chop1.Chop(3, new int[0]));
            Assert.AreEqual(-1, Chop1.Chop(3, new[] { 1 }));
            Assert.AreEqual(0, Chop1.Chop(1, new[] { 1 }));

            Assert.AreEqual(0, Chop1.Chop(1, new[] { 1, 3, 5 }));
            Assert.AreEqual(1, Chop1.Chop(3, new[] { 1, 3, 5 }));
            Assert.AreEqual(2, Chop1.Chop(5, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, Chop1.Chop(0, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, Chop1.Chop(2, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, Chop1.Chop(4, new[] { 1, 3, 5 }));
            Assert.AreEqual(-1, Chop1.Chop(6, new[] { 1, 3, 5 }));

            Assert.AreEqual(0, Chop1.Chop(1, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, Chop1.Chop(3, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(2, Chop1.Chop(5, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, Chop1.Chop(7, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, Chop1.Chop(0, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, Chop1.Chop(2, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, Chop1.Chop(4, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, Chop1.Chop(6, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, Chop1.Chop(8, new[] { 1, 3, 5, 7 }));
        }
    }
}
