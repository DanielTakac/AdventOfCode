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

                // Check if the other cube is adjacent on the x-axis
                if (Math.Abs(cube.Position[0] - this.Position[0]) <= 1 &&
                    cube.Position[1] == this.Position[1] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[0] = true;
                    this.Sides[1] = true;
                }

                // Check if the other cube is adjacent on the y-axis
                if (Math.Abs(cube.Position[1] - this.Position[1]) <= 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[2] == this.Position[2]) {
                    this.Sides[2] = true;
                    this.Sides[3] = true;
                }

                // Check if the other cube is adjacent on the z-axis
                if (Math.Abs(cube.Position[2] - this.Position[2]) <= 1 &&
                    cube.Position[0] == this.Position[0] &&
                    cube.Position[1] == this.Position[1]) {
                    this.Sides[4] = true;
                    this.Sides[5] = true;
                }

            }

        }

    }

}
