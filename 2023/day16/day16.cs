using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode {

    class Day16 : Day {

        protected override string Part1() {

            string[] input = AdventOfCode.GetInput();

            bool[,] tiles = new bool[input.Length, input[0].Length];

            tiles[0, 0] = true; // Set starting tile to true

            FollowLightBeam(input, tiles, 0, 0, Direction.Right, new List<Beam>());

            int energizedTiles = CountOfEnergizedTiles(tiles);

            return energizedTiles.ToString();

        }

        public enum Direction {
            Left,
            Right,
            Up,
            Down
        }

        public struct Beam {

            public int X { get; }
            public int Y { get; }
            public Direction Direction { get; }

            public Beam(int x, int y, Direction direction) {

                X = x;
                Y = y;
                Direction = direction;

            }

        }

        private static void FollowLightBeam(string[] tiles, bool[,] energizedTiles, int posX, int posY, Direction dir, List<Beam> visitedBeams) {

            // Already visited
            if (visitedBeams.Any(b => b.X == posX && b.Y == posY && b.Direction == dir)) {

                return;

            }

            visitedBeams.Add(new Beam(posX, posY, dir));

            int[] pos = [posX, posY];

            void RedirectBeam() {

                switch (tiles[pos[0]][pos[1]]) {

                    case '/':

                        switch (dir) {

                            case Direction.Left:
                                dir = Direction.Down;
                                break;
                            case Direction.Right:
                                dir = Direction.Up;
                                break;
                            case Direction.Up:
                                dir = Direction.Right;
                                break;
                            case Direction.Down:
                                dir = Direction.Left;
                                break;
                        }

                        break;
                    case '\\':

                        switch (dir) {

                            case Direction.Left:
                                dir = Direction.Up;
                                break;
                            case Direction.Right:
                                dir = Direction.Down;
                                break;
                            case Direction.Up:
                                dir = Direction.Left;
                                break;
                            case Direction.Down:
                                dir = Direction.Right;
                                break;
                        }

                        break;
                    case '|':

                        if (dir == Direction.Left || dir == Direction.Right) {

                            FollowLightBeam(tiles, energizedTiles, pos[0], pos[1], Direction.Up, visitedBeams);
                            FollowLightBeam(tiles, energizedTiles, pos[0], pos[1], Direction.Down, visitedBeams);
                            pos = [-1, -1];

                        }

                        break;
                    case '-':

                        if (dir == Direction.Up || dir == Direction.Down) {

                            FollowLightBeam(tiles, energizedTiles, pos[0], pos[1], Direction.Left, visitedBeams);
                            FollowLightBeam(tiles, energizedTiles, pos[0], pos[1], Direction.Right, visitedBeams);
                            pos = [-1, -1];

                        }

                        break;

                }

            }

            RedirectBeam();

            while (pos[0] >= 0 && pos[0] < tiles.Length &&
                   pos[1] >= 0 && pos[1] < tiles[0].Length) {

                // Move
                switch (dir) {

                    case Direction.Left:
                        pos[1]--;
                        break;
                    case Direction.Right:
                        pos[1]++;
                        break;
                    case Direction.Up:
                        pos[0]--;
                        break;
                    case Direction.Down:
                        pos[0]++;
                        break;

                }

                // Out of bounds
                if (!(pos[0] >= 0 && pos[0] < tiles.Length && pos[1] >= 0 && pos[1] < tiles[0].Length)) break;

                energizedTiles[pos[0], pos[1]] = true;

                RedirectBeam();

            }

        }

        private static int CountOfEnergizedTiles(bool[,] tiles) {

            int count = 0;

            foreach (var pos in tiles) {

                if (pos) {

                    count++;

                }

            }

            return count;

        }

        public class BeamConfig {

            public int X { get; }
            public int Y { get; }
            public Direction Direction { get; }
            public int EnergizedTiles { get; set; }

            public BeamConfig(int x, int y, Direction direction) {

                X = x;
                Y = y;
                Direction = direction;

            }

        }

        protected override string Part2() {

            string[] input = AdventOfCode.GetInput();

            List<BeamConfig> configs = [];

            for (int i = 0; i < input.Length; i++) {

                configs.Add(new BeamConfig(i, 0, Direction.Right));
                configs.Add(new BeamConfig(i, input[0].Length - 1, Direction.Left));

            }

            for (int i = 0; i < input[0].Length; i++) {

                configs.Add(new BeamConfig(0, i, Direction.Down));
                configs.Add(new BeamConfig(input.Length - 1, i, Direction.Up));

            }

            for (int i = 0; i < configs.Count; i++) {

                bool[,] tiles = new bool[input.Length, input[0].Length];

                tiles[configs[i].X, configs[i].Y] = true; // Set starting tile to true

                FollowLightBeam(input, tiles, configs[i].X, configs[i].Y, configs[i].Direction, new List<Beam>());

                configs[i].EnergizedTiles = CountOfEnergizedTiles(tiles);

            }

            int mostEnergizedTiles = configs.Max(x => x.EnergizedTiles);

            return mostEnergizedTiles.ToString();

        }

        static void Main(string[] args) {

            var day = new Day16();

            day.Solve();

            Console.ReadKey(true);

        }

    }

}
