using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    public class AdventOfCode {

        /// <summary>
        /// Reads the input text file
        /// </summary>
        /// <returns>String array with all lines from the text file</returns>
        /// <param name="path">The path to the input text file. Defaults to "input.txt"</param>
        public static string[] GetInput(string path = "input.txt") => File.ReadAllLines(path);

        /// <summary>
        /// Gets the number of lines from a text file
        /// </summary>
        /// <returns>Number of lines in a text file</returns>
        /// <param name="path">The path to the input text file. Defaults to "input.txt"</param>
        public static int GetInputLineCount(string path = "input.txt") => GetInput(path).Count();

        /// <summary>
        /// Gets the character count from a text file
        /// </summary>
        /// <returns>Number of characters in a text file</returns>
        /// <param name="path">The path to the input text file. Defaults to "input.txt"</param>
        public static int GetCharacterCount(string path = "input.txt") {

            string[] input = GetInput(path);

            int characterCount = 0;

            foreach (string line in input) {

                characterCount += line.Length;

            }

            return characterCount;

        }

        /// <summary>
        /// Gets the character count of the specified character from a text file
        /// </summary>
        /// <returns>Integer representing the number of occurrences of the specified character in a text file</returns>
        /// <param name="character">The character to search for</param>
        /// <param name="path">The path to the input text file. Defaults to "input.txt"</param>
        public static int GetCharacterCount(char character, string path = "input.txt") {

            string[] input = GetInput(path);

            int characterCount = 0;

            foreach (string line in input) {

                characterCount += line.Count(x => x == character);

            }

            return characterCount;

        }

        /// <summary>
        /// Prints text to the console with a specified color
        /// </summary>
        /// <param name="text">The text to be printed. Defaults to an empty string</param>
        /// <param name="color">The color of the text. Defaults to ConsoleColor.Green</param>
        public static void PrintWithColor(string text = "", ConsoleColor color = ConsoleColor.Green) {

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();

        }

    }

}
