using System;
using System.Collections.Generic;
using System.Linq;

namespace Dec16
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRaw = "59773590431003134109950482159532121838468306525505797662142691007448458436452137403459145576019785048254045936039878799638020917071079423147956648674703093863380284510436919245876322537671069460175238260758289779677758607156502756182541996384745654215348868695112673842866530637231316836104267038919188053623233285108493296024499405360652846822183647135517387211423427763892624558122564570237850906637522848547869679849388371816829143878671984148501319022974535527907573180852415741458991594556636064737179148159474282696777168978591036582175134257547127308402793359981996717609700381320355038224906967574434985293948149977643171410237960413164669930";
            int[] pattern = { 0, 1, 0, -1 };

            var input = SplitInput(inputRaw);
            for (int _ = 0; _ < 100; _++)
            {
                input = ApplyPattern(pattern, input);
            }

            Console.WriteLine(string.Join(' ', input.Take(8)));
        }

        private static List<int> ApplyPattern(int[] pattern, List<int> input)
        {
            int[] output = new int[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                var newPattern = CreateNewPattern(i, pattern);
                var partList = new List<int>();
                for (int j = 0; j < input.Count; j++)
                {
                    partList.Add(input[j] * newPattern[(j + 1) % newPattern.Count]);
                }

                output[i] = Math.Abs(partList.Sum() % 10);
            }
            return output.ToList();
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
                for (int j = 0; j < i + 1; j++)
                {
                    newPattern.Add(digit);
                }
            }
            return newPattern;
        }
    }
}
