using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day18 {
    
    class Cube {

        public int[] Position { get; set; }
        public bool[] Sides { get; set; }

        public Cube(int[] position) {

            Position = position;
            Sides = new bool[6];

        }

        public int NotTouchingSides() => this.Sides.Count(x => !x);

        public void CheckSides(List<Cube> cubes) {

            foreach (Cube cube in cubes) {

                if (cube == this) continue;

                if (cube.Position[0] == this.Position[0] - 1 &&
                    cube.Position[1] == this.Position[1] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[0] = true;
                }

                if (cube.Position[0] == this.Position[0] + 1 &&
                    cube.Position[1] == this.Position[1] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[1] = true;
                }

                if (cube.Position[1] == this.Position[1] - 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[2] = true;
                }

                if (cube.Position[1] == this.Position[1] + 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[3] = true;
                }

                if (cube.Position[2] == this.Position[2] - 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[1] == this.Position[1]) {
                    this.Sides[4] = true;
                }

                if (cube.Position[2] == this.Position[2] + 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[1] == this.Position[1]) {
                    this.Sides[5] = true;
                }

            }

        }

    }

}
