using System;
namespace P16_InstructionSet_broken
{
    class StartUp
    {
        static void Main()
        {
            var instruction = Console.ReadLine();

            while (instruction != "END")
            {
                var splitWords = instruction.Split(' ');
                var result = 0L;

                switch (splitWords[0])
                {
                    case "INC":
                        {
                            var operandOne = long.Parse(splitWords[1]);
                            result = ++operandOne;

                            break;
                        }
                    case "DEC":
                        {
                            var operandOne = long.Parse(splitWords[1]);
                            result = --operandOne;

                            break;
                        }
                    case "ADD":
                        {
                            var operandOne = long.Parse(splitWords[1]);
                            var operandTwo = long.Parse(splitWords[2]);
                            result = operandOne + operandTwo;

                            break;
                        }
                    case "MLA":
                        {
                            var operandOne = long.Parse(splitWords[1]);
                            var operandTwo = long.Parse(splitWords[2]);
                            result = operandOne * operandTwo;
                            
                            break;
                        }
                }

                Console.WriteLine(result);

                instruction = Console.ReadLine();
            }
        }
    }
}