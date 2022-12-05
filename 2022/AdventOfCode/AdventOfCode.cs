using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {
    
    public class AdventOfCode {

        public static string[] GetInput(bool demo = false, string path = "input.txt") {

            return File.ReadAllLines(path);

        }

    }

}
