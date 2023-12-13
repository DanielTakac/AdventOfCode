using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day11 : Day {

        protected override string Part1() {

            List<string> map = AdventOfCode.GetInput().ToList();

            List<string> expandedMap = ExpandMap(map);

            List<int[]> galaxies = GetGalaxies(expandedMap);

            int totalSteps = 0;

            for (int i = 0; i < galaxies.Count; i++)
                for (int j = i + 1; j < galaxies.Count; j++)
                    totalSteps += ShortestPath(expandedMap, galaxies[i], galaxies[j]);

            return totalSteps.ToString();

        }

        private List<int[]> GetGalaxies(List<string> map) {

            List<int[]> galaxies = [];

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    if (map[i][j] == '#') {

                        galaxies.Add([i, j]);

                    }

                }

            }

            return galaxies;

        }

        private void PrintMap(List<string> map) {

            int galaxyCounter = 1;

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    switch (map[i][j]) {

                        case '#':
                            AdventOfCode.PrintWithColor(galaxyCounter, ConsoleColor.Yellow, false);
                            galaxyCounter++;
                            break;
                        case 'X':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Cyan, false);
                            break;
                        case '$':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Blue, false);
                            break;
                        case '@':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Magenta, false);
                            break;
                        case '.':
                            Console.Write(map[i][j]);
                            break;

                    }

                }

                Console.WriteLine();

            }

        }

        private void PrintMap(List<string> map, List<int[]> visited) {

            int galaxyCounter = 1;

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    if (visited.Any(x => x[0] == i && x[1] == j)) {

                        AdventOfCode.PrintWithColor('#', ConsoleColor.Green, false);
                        continue;

                    }

                    switch (map[i][j]) {

                        case '#':
                            AdventOfCode.PrintWithColor(galaxyCounter, ConsoleColor.Yellow, false);
                            galaxyCounter++;
                            break;
                        case 'X':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Cyan, false);
                            break;
                        case '$':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Blue, false);
                            break;
                        case '@':
                            AdventOfCode.PrintWithColor(map[i][j], ConsoleColor.Magenta, false);
                            break;
                        case '.':
                            Console.Write(map[i][j]);
                            break;

                    }

                }

                Console.WriteLine();

            }

        }

        private List<string> ExpandMap(List<string> map) {

            List<int[]> galaxies = GetGalaxies(map);

            // Clone map
            List<string> expandedMap = new List<string>(map);

            string emptyRow = "";

            for (int i = 0; i < expandedMap[0].Length; i++) {

                emptyRow += ".";

            }

            // Expand rows
            for (int row = 0; row < expandedMap.Count; row++) {

                // If there are no galaxies on this row
                if (!galaxies.Any(x => x[0] == row)) {

                    expandedMap.Insert(row, emptyRow);

                    // Move all galaxies up by one
                    foreach (int[] galaxy in galaxies) {

                        if (galaxy[0] > row) {

                            galaxy[0]++;

                        }

                    }

                    row++;

                }

            }

            // Expand columns
            for (int column = 0; column < expandedMap[0].Length; column++) {

                // If there are no galaxies on this column
                if (!galaxies.Any(x => x[1] == column)) {

                    // Insert a column at each row
                    for (int row = 0; row < expandedMap.Count; row++) {

                        expandedMap[row] = expandedMap[row].Insert(column, ".");

                    }

                    // Move all galaxies up by one
                    foreach (int[] galaxy in galaxies) {

                        if (galaxy[1] > column) {

                            galaxy[1]++;

                        }

                    }

                    column++;

                }

            }

            return expandedMap;

        }

        private int ShortestPath(List<string> map, int[] galaxy1, int[] galaxy2) {

            int rows = map.Count;
            int cols = map[0].Length;

            // Direction vectors for up, down, left, and right movements
            int[] dx = [-1, 1, 0, 0];
            int[] dy = [0, 0, -1, 1];

            Queue<int[]> queue = new Queue<int[]>();
            bool[,] visited = new bool[rows, cols];

            queue.Enqueue(galaxy1);
            visited[galaxy1[0], galaxy1[1]] = true;
            int steps = 0;

            while (queue.Count > 0) {

                int count = queue.Count;

                for (int i = 0; i < count; i++) {

                    int[] current = queue.Dequeue();

                    if (current[0] == galaxy2[0] && current[1] == galaxy2[1]) {

                        return steps;
                    
                    }

                    for (int j = 0; j < 4; j++) {

                        int newX = current[0] + dx[j];
                        int newY = current[1] + dy[j];

                        if (newX >= 0 && newX < rows && newY >= 0 && newY < cols &&
                            !visited[newX, newY]) {

                            queue.Enqueue(new int[] { newX, newY });
                            visited[newX, newY] = true;
                        
                        }
                    
                    }
                
                }
                
                steps++;
            
            }

            // If no path found
            return -1;

        }

        private List<string> ExpandMapPart2(List<string> map) {

            List<int[]> galaxies = GetGalaxies(map);

            // Clone map
            List<string> expandedMap = new List<string>(map);

            // Expand rows
            for (int row = 0; row < expandedMap.Count; row++) {

                // If there are no galaxies on this row
                if (!galaxies.Any(x => x[0] == row)) {

                    expandedMap[row] = expandedMap[row].Replace('.', 'X');

                }

            }

            // Expand columns
            for (int column = 0; column < expandedMap[0].Length; column++) {

                // If there are no galaxies on this column
                if (!galaxies.Any(x => x[1] == column)) {

                    // Insert a column at each row
                    for (int row = 0; row < expandedMap.Count; row++) {

                        if (expandedMap[row][column] == 'X') {

                            expandedMap[row] = new StringBuilder(expandedMap[row]) { [column] = '@' }.ToString();

                        } else {

                            expandedMap[row] = new StringBuilder(expandedMap[row]) { [column] = '$' }.ToString();

                        }

                    }

                }

            }

            return expandedMap;

        }

        private (int, List<int[]>) ShortestPathPart2(List<string> map, int[] g1, int[] g2) {

            int rows = map.Count;
            int columns = map[0].Length;

            List<int[]> visited = [];

            int steps = 0;

            int[] pos = g1;
            int[] end = g2;

            // While g2 is not directly above or to the right of g1
            while (pos[0] != end[0] && pos[1] != end[1]) {

                // go up
                pos[0]--;
                steps++;
                visited.Add([pos[0], pos[1]]);

                // go right
                pos[1]++;
                steps++;
                visited.Add([pos[0], pos[1]]);

            }

            // If on the same row
            if (pos[0] == end[0]) {

                // While not on the same column
                while (pos[1] != end[1]) {

                    if (map[pos[0]][pos[1]] == '$') {

                        steps += 100000000;

                    }

                    // Go right
                    pos[1]++;
                    steps++;
                    visited.Add([pos[0], pos[1]]);

                }

              // If on the same column
            } else if (pos[1] == end[1]) {

                // While not on the same row
                while (pos[0] != end[0]) {

                    // Go up
                    pos[0]--;
                    steps++;
                    visited.Add([pos[0], pos[1]]);

                }

            }

            if (pos[0] == end[0] && pos[1] == end[1]) {

                if (steps != visited.Count) {

                    AdventOfCode.PrintWithColor("Steps is not equal to visited.Count!", ConsoleColor.Red);

                }

                return (steps, visited);

            } else {

                // If no path found
                AdventOfCode.PrintWithColor("We are still not at the end!", ConsoleColor.Red);
                return (-1, []);
                
            }

        }

        protected override string Part2() {

            List<string> map = AdventOfCode.GetInput("example.txt").ToList();

            foreach (string line in map) Console.WriteLine(line);

            Console.WriteLine();

            PrintMap(map);

            Console.WriteLine();

            List<string> expandedMap = ExpandMapPart2(map);

            PrintMap(expandedMap);

            List<int[]> galaxies = GetGalaxies(expandedMap);

            int g1 = 4;
            int g2 = 1;
            int steps1 = ShortestPath(expandedMap, galaxies[g1], galaxies[g2]);
            (int, List<int[]>) path = ShortestPathPart2(expandedMap, galaxies[g1], galaxies[g2]);

            int steps = path.Item1;
            List<int[]> visited = path.Item2;

            foreach (int[] vis in visited) Console.WriteLine("[" + vis[0] + " " + vis[1] + "]");

            Console.WriteLine();

            Console.WriteLine(visited[0][1]);

            PrintMap(expandedMap, visited);

            int totalSteps = 0;

            /*for (int i = 0; i < galaxies.Count; i++)
                for (int j = i + 1; j < galaxies.Count; j++)
                    totalSteps += ShortestPathPart2(expandedMap, galaxies[i], galaxies[j]).Item1;*/


            AdventOfCode.PrintWithColor("\nShortest path between galaxies 1: " + steps1);
            AdventOfCode.PrintWithColor("Shortest path between galaxies 2: " + steps + "\n");

            return totalSteps.ToString();

        }

        static void Main(string[] args) {

            var day = new Day11();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
