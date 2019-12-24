using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LargeRegex;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private string _allData = string.Empty;

        [SetUp]
        public void Setup()
        {
            this._allData = File.ReadAllText(@"blacklist-12070.txt");
        }

        [TestCase("paul@hotmail.com", true)]
        [TestCase("paul@hotmail.se", false)]
        [TestCase("paul@150ml.com", true)]
        [TestCase("my.name@student.cccs.edu", false)]
        public void Test_BasicRegexCheckOnDecentList(string email, bool expectedResult)
        {
           var allBlackList = _allData
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(brs => !string.IsNullOrWhiteSpace(brs))
                .Select(brs => new Regex(brs.Trim(), RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5)))
                .ToArray();

            var checker = new BlacklistChecker(allBlackList);
            var result = checker.IsBlacklisted(email);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("paul@hotmail.com", true)]
        [TestCase("paul@hotmail.se", false)]
        [TestCase("paul@150ml.com", true)]
        public void Test_TimeoutRegexCheckOnDecentList(string email, bool expectedResult)
        {
            var allBlackList = _allData
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(brs => !string.IsNullOrWhiteSpace(brs))
                .Select(brs => new Regex(brs.Trim(), RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5)))
                .ToArray();

            var checker = new BlacklistChecker(allBlackList);
            var result = checker.IsBlacklistedWithTimeout(email);

            Assert.AreEqual(expectedResult, result);
        }

    }
}