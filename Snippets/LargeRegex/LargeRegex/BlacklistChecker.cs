using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargeRegex
{
    public class BlacklistChecker
    {
        public IEnumerable<Regex> BlackListRegexStore { get; set; }

        public BlacklistChecker(IEnumerable<Regex> blackListRegexStore)
        {
            BlackListRegexStore = blackListRegexStore;
        }

        public bool IsBlacklisted(string email)
        {
            return BlackListRegexStore?.Any(r => r.IsMatch(email)) ?? false;
        }

        public bool IsBlacklistedWithTimeout(string email)
        {
            return this.BlackListRegexStore?.Any(r => this.TimeoutSafeRegexMatch(r, email)) ?? false;
        }

        private bool TimeoutSafeRegexMatch(Regex regex, string email)
        {
            if (regex.MatchTimeout.Equals(Regex.InfiniteMatchTimeout))
                throw new ArgumentException("Provided Regex does not have a MatchTimeout set");

            try
            {
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException ex)
            {
                return false;
            }
        }

    }
}