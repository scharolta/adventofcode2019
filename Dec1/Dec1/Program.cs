using System;
using System.IO;
using System.Linq;

namespace Dec1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\ssk\source\repos\Xmas\Dec1\input1.txt";
            int answer = File.ReadAllLines(filePath)
                .Select(l => CalculateFuelReqRecursive(int.Parse(l), 0))
                .Sum();
            Console.WriteLine(answer);
        }

        static int CalculateFuelReq(int inputNr)
        {
            return (inputNr / 3) - 2;
        }

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
