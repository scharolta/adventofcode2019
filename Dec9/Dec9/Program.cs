using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"C:\Users\ssk\source\repos\Dec\Dec9\input8.txt");

            var allLayers = new List<char[,]>();
            char[,] currentLayer = new char[6, 25];

            for (int i = 0; i < input.Length; i++)
            {
                if (i % (6*25) == 0 && i > 0)
                {
                    allLayers.Add(currentLayer);
                    currentLayer = new char[6, 25];
                }
                currentLayer[i/25 % 6, i % 25] = input[i];
            }

            char[,] finalLayer = allLayers[0];
            PrintLayer(finalLayer);
            Console.WriteLine();
            for (int i = 0; i < allLayers[0].GetLength(0); i++)
            {
                for (int j = 0; j < allLayers[1].GetLength(1); j++)
                {
                    var field = finalLayer[i, j];
                    foreach (var layer in allLayers.Skip(1))
                    {
                        if (field == 2 && layer[i, j] != 2)
                        {
                            field = layer[i, j];
                        }
                    }
                    finalLayer[i, j] = field == '0' ? '1' : '0';
                }
            }

            PrintLayer(finalLayer);
        }

        private static void PrintLayer(char[,] finalLayer)
        {
            for (int i = 0; i < finalLayer.GetLength(0); i++)
            {
                for (int j = 0; j < finalLayer.GetLength(1); j++)
                {
                    Console.Write(finalLayer[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
