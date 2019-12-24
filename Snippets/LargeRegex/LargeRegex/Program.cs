using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargeRegex
{
    static class Program
    {
        static void Main(string[] args)
        {
            var smallBlacklist = @"hotmail.co.uk
            hotmail.com
            gmail.com
            live.co.uk
            yahoo.co.uk
            yahoo.com
            msn.com
            aol.com
            live.com
            btinternet.com
            googlemail.com
            me.com
            ymail.com
            sky.com
            live.dk
            ntlworld.com
            live.com.au
            qq.com
            yahoo.com.tw
            talktalk.net
            hotmail.co.nz
            live.ie
            aol.co.uk
            mail.ru
            accamail.com
            yahoo.ie
            hotmail.fr
            mail.itsligo.ie
            hotmail.dk
            mail.com
            gmail.co.uk
            eircom.net
            hanmail.net
            yahoo.com.hk
            rocketmail.com
            icloud.com
            tiscali.co.uk
            126.com
            att.net
            163.com
            nhs.net
            bt.com
            btopenworld.com
            yahoo.com.au
            blueyonder.co.uk
            hotmail.com.au
            o2.com"
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(brs => !string.IsNullOrWhiteSpace(brs))
                .Select(brs => new Regex(brs.Trim(), RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5)))
                .ToArray();

            var checker = new BlacklistChecker(smallBlacklist);
            var result = checker.IsBlacklisted("paul@hotmail.com");

            var result2 = checker.IsBlacklistedWithTimeout("paul@hotmail.com");


        }

    }
}
