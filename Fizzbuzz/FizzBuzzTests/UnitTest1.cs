using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FizzBuzzTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Fizzbuzz_HappyPath_OneToTen()
        {
            var results = Fizzbuzz.Program.doFizzBuzz(10);

            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz" };

            Assert.AreEqual(10, results.Count);

            //does not do what i expected (sure this works in other test frameworks such as nunit)
            //Assert.AreEqual(expected, results);
            //So i will loop instead...

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i], results[i]);
            }
        }

        [TestMethod]
        public void Fizzbuzz_HappyPath_OneToTwenty()
        {
            var results = Fizzbuzz.Program.doFizzBuzz(20);

            var expected = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
            "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz"};

            Assert.AreEqual(20, results.Count);

            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(expected[i], results[i]);
            }
        }
    }
}
