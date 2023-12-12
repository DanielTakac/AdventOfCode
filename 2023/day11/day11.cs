using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day11 : Day {

        protected override string Part1() {

            List<string> map = AdventOfCode.GetInput("input.txt").ToList();

            foreach (string line in map) Console.WriteLine(line);

            Console.WriteLine();

            PrintMap(map);

            Console.WriteLine();

            List<string> expandedMap = ExpandMap(map);

            PrintMap(expandedMap);

            List<int[]> galaxies = GetGalaxies(expandedMap);

            int steps = ShortestPath(expandedMap, galaxies[7], galaxies[8]);

            int totalSteps = 0;

            for (int i = 0; i < galaxies.Count; i++)
                for (int j = i + 1; j < galaxies.Count; j++)
                    totalSteps += ShortestPath(expandedMap, galaxies[i], galaxies[j]);

            AdventOfCode.PrintWithColor("\nShortest path between galaxies: " + steps + "\n");

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

            int counter = 1;

            for (int i = 0; i < map.Count; i++) {

                for (int j = 0; j < map[i].Length; j++) {

                    if (map[i][j] == '#') {

                        AdventOfCode.PrintWithColor(counter, ConsoleColor.Yellow, false);

                        counter++;

                    } else {

                        Console.Write(map[i][j]);

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

        protected override string Part2() {

            return string.Empty;

        }

        static void Main(string[] args) {

            var day = new Day11();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
