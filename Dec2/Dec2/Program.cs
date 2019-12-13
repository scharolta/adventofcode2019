using System;
using System.Linq;

namespace Dec2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,9,19,1,13,19,23,2,23,9,27,1,6,27,31,2,10,31,35,1,6,35,39,2,9,39,43,1,5,43,47,2,47,13,51,2,51,10,55,1,55,5,59,1,59,9,63,1,63,9,67,2,6,67,71,1,5,71,75,1,75,6,79,1,6,79,83,1,83,9,87,2,87,10,91,2,91,10,95,1,95,5,99,1,99,13,103,2,103,9,107,1,6,107,111,1,111,5,115,1,115,2,119,1,5,119,0,99,2,0,14,0";
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var inputParsed = input.Split(',').Select(i => int.Parse(i)).ToArray();
                    inputParsed[1] = i;
                    inputParsed[2] = j;

                    bool not99 = true;
                    int counter = 0;
                    while (not99 && inputParsed.Length > counter)
                    {
                        var position = counter++ * 4;
                        try
                        {
                            switch (inputParsed[position])
                            {
                                case 1: Addition(position, inputParsed); break;
                                case 2: Multiplication(position, inputParsed); break;
                                case 99: not99 = false; break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        { break; }
                    }

                    if (inputParsed[0] == 19690720)
                    {
                        Console.WriteLine($"Position 1: {i}; Position 2: {j}");
                        return;
                    }
                }
            }
        }

        static void Addition(int position, int[] inputInts)
        {
            var addedValue = inputInts[inputInts[position + 1]] + inputInts[inputInts[position + 2]];
            inputInts[inputInts[position + 3]] = addedValue;
        }

        static void Multiplication(int position, int[] inputInts)
        {
            var addedValue = inputInts[inputInts[position + 1]] * inputInts[inputInts[position + 2]];
            inputInts[inputInts[position + 3]] = addedValue;
        }
    }
}
