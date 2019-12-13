using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec4
{
    class Program
    {
        static void Main(string[] args)
        {
            int validPasswords = 0;
            for (int i = 307237; i <= 769058; i++)
            {
                if (ApplyRules(i))
                {
                    validPasswords++;
                }
            }
            Console.WriteLine(validPasswords);
        }

        private static bool ApplyRules(int number)
        {
            var minDigit = 0;
            var numberString = number.ToString();
            int sameAdjacent = 1;
            bool twoAdjacent = false;

            for (int i = 0; i < numberString.Length; i++)
            {
                int parsedDigit = (int)char.GetNumericValue(numberString[i]);
                
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
    }
}
