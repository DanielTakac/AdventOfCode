using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    public class AdventOfCode {

        public static string[] GetInput(string path = "input.txt") => File.ReadAllLines(path);

        public static int GetInputLineCount(string path = "input.txt") => GetInput(path).Count();

        public static int GetCharacterCount(string path = "input.txt") {

            string[] input = GetInput(path);

            int characterCount = 0;

            foreach (string line in input) {

                characterCount += line.Length;

            }

            return characterCount;

        }

        public static int GetCharacterCount(char character, string path = "input.txt") {

            string[] input = GetInput(path);

            int characterCount = 0;

            foreach (string line in input) {

                characterCount += line.Count(x => x == character);

            }

            return characterCount;

        }

        public static void PrintWithColor(string text = "", ConsoleColor color = ConsoleColor.Green) {

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();

        }

    }

}
