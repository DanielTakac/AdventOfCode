namespace day9_visualization {

    public partial class Form1 : Form {

        public Form1() {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e) {

            var timer = new System.Windows.Forms.Timer() {

                Interval = 500 //ms
            
            };

            timer.Tick += Timer_Tick;

            string[] input = AdventOfCode.AdventOfCode.GetInput();

            int[] head = new int[] { 0, 0 };
            int[] tail = new int[] { 0, 0 };

            List<int[]> visitedPositions = new List<int[]> {
                new int[] { 0, 0 }
            };

            dataGridView1.DataSource = visitedPositions;

            foreach (string line in input) {

                char direction = line[0];
                int distance = int.Parse(line.Split(' ')[1]);

            }

        }

        public async void Timer_Tick(object sender, EventArgs e) {

            // your code here
        
        }

    }

}
