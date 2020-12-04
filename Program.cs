/*
Commands:
    YES YES YES - Increments accumulator.
    YES YES - Pauses execution and asks for input as an ascii number.
    YES - Terminates program.
    NO NO NO - Decrements accumulator.
    NO NO - Prints accumulator as an ASCII character.
    NO - Jumps to last instruction where the value of the accumulator was 0.

*/
using System;
using System.IO;
using System.Collections.Generic;


namespace IsThatAMotherFrickingSpecificAnimeReferenceLang
{
    class Program
    {

        static Dictionary<string, int> Operations = new Dictionary<string, int>();

        static int LastZeroInstruction = 0;
        static int ProgramCounter = 0;
        static byte Accumulator = 0;


        static void Main(string[] args)
        {

            Operations.Add("YES YES YES", (int)OperationIDS.YES_YES_YES);
            Operations.Add("YES YES", (int)OperationIDS.YES_YES);
            Operations.Add("YES", (int)OperationIDS.YES);
            Operations.Add("NO", (int)OperationIDS.NO);
            Operations.Add("NO NO", (int)OperationIDS.NO_NO);
            Operations.Add("NO NO NO", (int)OperationIDS.NO_NO_NO);


            if (args.Length != 1)
            {
                Console.WriteLine("Invalid command line arguments!");
                Console.ReadLine();
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File doesn't exist!");
                Console.ReadLine();
                return;
            }

            var instructions = File.ReadAllLines(args[0]);

            while (true)
            {
                try
                {
                    switch (Operations[instructions[ProgramCounter]])
                    {

                        case (int)OperationIDS.YES_YES_YES:
                            ++Accumulator;
                            break;

                        case (int)OperationIDS.YES_YES:
                            Accumulator = (byte)Console.Read();
                            break;

                        case (int)OperationIDS.YES:
                            Console.WriteLine("\n\nEnd of program!");
                            Console.ReadLine();
                            return;

                        case (int)OperationIDS.NO:
                            ProgramCounter = LastZeroInstruction;
                            break;

                        case (int)OperationIDS.NO_NO:
                            Console.Write((char)Accumulator);
                            break;

                        case (int)OperationIDS.NO_NO_NO:
                            --Accumulator;
                            break;

                        default:
                            Console.WriteLine("You shouldn't be seeing this message! This is an interpreter bug!");
                            Console.ReadLine();
                            return;
                    }

                }
                catch (KeyNotFoundException) { }

                ++ProgramCounter;

                if (ProgramCounter >= instructions.Length)
                {
                    ProgramCounter = 0;
                }
            }


        }
    }

    enum OperationIDS
    {
        YES_YES_YES = 0,
        YES_YES = 1,
        YES = 2,
        NO = 3,
        NO_NO = 4,
        NO_NO_NO = 5,
    }
}
