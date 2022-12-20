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

    }

}
