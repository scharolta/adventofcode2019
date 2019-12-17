using System;
using System.IO;
using System.Linq;

namespace Dec1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(@"C:\Users\ssk\source\repos\Dec\Dec1\input1.txt");
            int answer1 = inputLines
                .Select(l => CalculateFuelReq(int.Parse(l)))
                .Sum();

            int answer2 = inputLines
                .Select(l => CalculateFuelReqRecursive(int.Parse(l), 0))
                .Sum();

            Console.WriteLine($"Answer1: {answer1}\nAnswer2: {answer2}");
        }

        static int CalculateFuelReq(int inputNr) => (inputNr / 3) - 2;

        static int CalculateFuelReqRecursive(int inputNr, int total)
        {
            var fuelReq = (inputNr / 3) - 2;
            if (fuelReq > 0)
                return CalculateFuelReqRecursive(fuelReq, total + fuelReq);
            else
                return total;
        }
    }
}
