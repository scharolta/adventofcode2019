using System;
using System.Collections.Generic;
using System.Linq;

namespace Dec16
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRaw = "12345678";
            int[] pattern = { 0, 1, 0, -1 };

            var input = SplitInput(inputRaw); 
            int[] output = new int[input.Count];
            for (int i = 0; i < inputRaw.Length; i++)
            {
                var newPattern = CreateNewPattern(i, pattern);
                var partList = new List<int>();
                for (int j = 0; j < input.Count; j++)
                {
                    partList.Add(input[j] * newPattern[j % newPattern.Count]);
                }

                input = partList;
                output[i] = Math.Abs(partList.Sum() % 10);
            }

            Console.WriteLine(string.Join(' ', output));
        }

        private static List<int> SplitInput(string inputRaw)
        {
            var digits = new List<int>();
            foreach (char digChar in inputRaw)
            {
                digits.Add(int.Parse(digChar.ToString()));
            }
            return digits;
        }

        private static List<int> CreateNewPattern(int i, int[] pattern)
        {
            var newPattern = new List<int>();
            foreach (var digit in pattern)
            {
                for (int j = 0; j < i+2; j++)
                {
                    newPattern.Add(digit);
                }
            }
            if (i == 0) return newPattern.Skip(1).ToList();
            return newPattern;
        }
    }
}
