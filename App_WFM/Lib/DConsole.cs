using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.AppWFM.Lib
{
    public static class DConsole
    {
        /// <summary>
        /// Prints a list of string
        /// </summary>
        /// <param name="list">list entries</param>
        /// <param name="listname">list name</param>
        public static void PrintList(List<string> list, string listname)
        {
            Print(" - " + listname + " - ", ConsoleColor.White);
            int count = 0;
            foreach (var i in list)
            {
                Print("" + count + " " + i, ConsoleColor.Gray);
                count++;
            }
        }

        /// <summary>
        /// Write line with given color
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Print(string message, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        /// <summary>
        /// ReadLine in color magenta
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            string input = Console.ReadLine();
            Console.ForegroundColor = currentColor;

            return input;
        }

        /// <summary>
        /// Simple write
        /// </summary>
        /// <param name="message"></param>
        public static void Print(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Simple write line
        /// </summary>
        /// <param name="message"></param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Write empty line
        /// </summary>
        public static void PrintEmptyLines()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Write empty lines
        /// </summary>
        /// <param name="numberOfLines">Number of empty Lines</param>
        public static void PrintEmptyLines(int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print [Done] in green
        /// </summary>
        public static void PrintDone()
        {
            Print("[Done]", ConsoleColor.Green);
        }

        /// <summary>
        /// Print [Failed] in red
        /// </summary>
        public static void PrintFailed()
        {
            Print("[Failed]", ConsoleColor.Red);
        }

        /// <summary>
        /// Read int between 0 und max
        /// </summary>
        /// <param name="max">max int value</param>
        /// <returns></returns>
        public static int ReadInt(int max)
        {
            int input = -1;

            while (input < 0 || input >= max)
            {
                Console.Write("int: ");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    input = -1;
                }
            }

            return input;
        }
    }
}
