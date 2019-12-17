using System;
using System.Linq;

namespace Dec4
{
    class Program
    {
        static void Main(string[] _)
        {
            int validPasswordsPart1 = 0;
            int validPasswordsPart2 = 0;

            for (int i = 307237; i <= 769058; i++)
            {
                var digitString = i.ToString();
                if (ApplyRules(digitString, c => c >= 2)) validPasswordsPart1++;
                if (ApplyRules(digitString, c => c == 2)) validPasswordsPart2++;
            }

            Console.WriteLine($"Answer1: {validPasswordsPart1}\nAnswer2: {validPasswordsPart2}");
        }

        //ORIGINAL SOLUTION
        private static bool ApplyRulesPart1(string digits)
        {
            var minDigit = 0;
            bool sameAdjacent = false;

            for (int i = 0; i < digits.Length; i++)
            {
                int parsedDigit = int.Parse(digits[i].ToString());

                if (parsedDigit > minDigit) minDigit = parsedDigit;
                else if (parsedDigit == minDigit) sameAdjacent = true;
                else return false;
            }

            return sameAdjacent;
        }
        private static bool ApplyRulesPart2(string digits)
        {
            var minDigit = 0;
            int sameAdjacent = 1;
            bool twoAdjacent = false;

            for (int i = 0; i < digits.Length; i++)
            {
                int parsedDigit = (int)char.GetNumericValue(digits[i]);

                if (parsedDigit > minDigit)
                {
                    minDigit = parsedDigit;
                    if (sameAdjacent == 2) twoAdjacent = true;
                    sameAdjacent = 1;
                }

                else if (parsedDigit == minDigit)
                {
                    if (!twoAdjacent) sameAdjacent++;
                }

                else return false;
            }

            return sameAdjacent == 2 || twoAdjacent;
        }

        //SMARTER SOLUTION (very compressed and not so readable)
        private static bool ApplyRules(string digits, Func<int, bool> countEval)
        {
            return Enumerable.SequenceEqual(digits, digits.OrderBy(d => d)) 
                && digits.GroupBy(d => d).Any(g => countEval(g.Count()));
        }
    }
}
