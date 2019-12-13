using System;
using System.Linq;

namespace Dec2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "3,225,1,225,6,6,1100,1,238,225,104,0,2,106,196,224,101,-1157,224,224,4,224,102,8,223,223,1001,224,7,224,1,224,223,223,1002,144,30,224,1001,224,-1710,224,4,224,1002,223,8,223,101,1,224,224,1,224,223,223,101,82,109,224,1001,224,-111,224,4,224,102,8,223,223,1001,224,4,224,1,223,224,223,1102,10,50,225,1102,48,24,224,1001,224,-1152,224,4,224,1002,223,8,223,101,5,224,224,1,223,224,223,1102,44,89,225,1101,29,74,225,1101,13,59,225,1101,49,60,225,1101,89,71,224,1001,224,-160,224,4,224,1002,223,8,223,1001,224,6,224,1,223,224,223,1101,27,57,225,102,23,114,224,1001,224,-1357,224,4,224,102,8,223,223,101,5,224,224,1,224,223,223,1001,192,49,224,1001,224,-121,224,4,224,1002,223,8,223,101,3,224,224,1,223,224,223,1102,81,72,225,1102,12,13,225,1,80,118,224,1001,224,-110,224,4,224,102,8,223,223,101,2,224,224,1,224,223,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,7,677,226,224,102,2,223,223,1005,224,329,101,1,223,223,108,226,226,224,102,2,223,223,1006,224,344,101,1,223,223,1108,226,677,224,102,2,223,223,1006,224,359,1001,223,1,223,107,677,677,224,1002,223,2,223,1005,224,374,1001,223,1,223,1107,226,677,224,102,2,223,223,1005,224,389,1001,223,1,223,107,677,226,224,1002,223,2,223,1005,224,404,101,1,223,223,8,226,677,224,102,2,223,223,1005,224,419,101,1,223,223,7,226,677,224,1002,223,2,223,1005,224,434,101,1,223,223,1007,677,677,224,102,2,223,223,1006,224,449,1001,223,1,223,107,226,226,224,1002,223,2,223,1006,224,464,1001,223,1,223,1007,226,226,224,102,2,223,223,1006,224,479,1001,223,1,223,1008,226,226,224,102,2,223,223,1006,224,494,101,1,223,223,7,677,677,224,102,2,223,223,1005,224,509,1001,223,1,223,108,677,226,224,102,2,223,223,1005,224,524,101,1,223,223,1108,677,226,224,1002,223,2,223,1006,224,539,101,1,223,223,1108,677,677,224,102,2,223,223,1005,224,554,101,1,223,223,8,677,226,224,102,2,223,223,1005,224,569,101,1,223,223,8,677,677,224,102,2,223,223,1005,224,584,101,1,223,223,1107,226,226,224,102,2,223,223,1006,224,599,101,1,223,223,108,677,677,224,102,2,223,223,1006,224,614,101,1,223,223,1008,677,226,224,1002,223,2,223,1005,224,629,1001,223,1,223,1107,677,226,224,102,2,223,223,1005,224,644,101,1,223,223,1008,677,677,224,1002,223,2,223,1005,224,659,101,1,223,223,1007,677,226,224,1002,223,2,223,1005,224,674,1001,223,1,223,4,223,99,226";
            //var input = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";
            var inputParsed = input.Split(',').Select(i => int.Parse(i)).ToArray();

            bool not99 = true;
            int position = 0;
            while (not99)
            {
                switch (inputParsed[position] % 10)
                {
                    case 1: DoOperation(position, inputParsed, Addition); position += 4; break;
                    case 2: DoOperation(position, inputParsed, Multiplication); position += 4; break;
                    case 3: InputCode(position, inputParsed); position += 2; break;
                    case 4: OutputCode(position, inputParsed); position += 2; break;
                    case 5: position = JumpIfCondition(position, inputParsed, input => input != 0); break;
                    case 6: position = JumpIfCondition(position, inputParsed, input => input == 0); break;
                    case 7: ChangeGivenCondition(position, inputParsed, (input1, input2) => input1 < input2); position += 4; break;
                    case 8: ChangeGivenCondition(position, inputParsed, (input1, input2) => input1 == input2); position += 4; break;
                    case 9: not99 = false; break;
                }
            }
        }

        private static void ChangeGivenCondition(int position, int[] inputInts, Func<int, int, bool> condition)
        {
            var param1 = AssessCode(position, inputInts, 100, 1);
            var param2 = AssessCode(position, inputInts, 1000, 2);
            var param3 = AssessCodeLocation(position, inputInts, 10000, 3);

            inputInts[param3] = (condition(param1, param2)) ? 1 : 0;
        }

        private static int JumpIfCondition(int position, int[] inputInts, Func<int, bool> condition)
        {
            var param1 = AssessCode(position, inputInts, 100, 1);
            var param2 = AssessCode(position, inputInts, 1000, 2);
            return (condition(param1)) ? param2 : position + 3;
        }

        private static void OutputCode(int position, int[] inputParsed)
        {
            int output = AssessCode(position, inputParsed, 100, 1);
            Console.WriteLine(output);
        }

        private static void InputCode(int position, int[] inputParsed)
        {
            Console.Write("Input int: ");
            var inputNr = int.Parse(Console.ReadLine());
            int inputAddress = AssessCodeLocation(position, inputParsed, 100, 1);
            inputParsed[inputAddress] = inputNr;
        }

        static void DoOperation(int position, int[] inputInts, Action<int[], int, int, int> operation)
        {
            var param1 = AssessCode(position, inputInts, 100, 1);
            var param2 = AssessCode(position, inputInts, 1000, 2);
            var param3 = AssessCodeLocation(position, inputInts, 10000, 3);
            operation(inputInts, param1, param2, param3);
        }

        private static void Addition(int[] inputInts, int param1, int param2, int param3)
        {
            inputInts[param3] = param1 + param2;
        }

        static void Multiplication(int[] inputInts, int param1, int param2, int param3)
        {
            inputInts[param3] = param1 * param2;
        }

        private static int AssessCode(int position, int[] inputInts, int size, int positionRel)
        {
            return (inputInts[position] / size > 0 && inputInts[position] / size % 10 != 0) ?
                inputInts[position + positionRel] : inputInts[inputInts[position + positionRel]];
        }

        private static int AssessCodeLocation(int position, int[] inputInts, int size, int positionRel)
        {
            return (inputInts[position] / size > 0 && inputInts[position] / size % 10 != 0) ?
                position + positionRel : inputInts[position + positionRel];
        }
    }
}
