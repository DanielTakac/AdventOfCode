using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13 {
    
    public static class ListParser {

        public static Queue<char> StringToQueue(string stringToParse) {

            var queue = new Queue<char>();

            foreach (char ch in stringToParse) {

                queue.Enqueue(ch);

            }

            return queue;
            
        }

        public static int ParseInt(Queue<char> queue) {

            var number = new StringBuilder();

            while (queue.Count > 0 && char.IsDigit(queue.Peek())) {

                number.Append(queue.Dequeue());

            }

            return int.Parse(number.ToString());

        }

        public static List<object> ParseList(Queue<char> queue) {

            var list = new List<object>();

            while (queue.Count > 0 && queue.Peek() != ']') {

                if (char.IsDigit(queue.Peek())) {

                    list.Add(ParseInt(queue));

                } else if (queue.Peek() == '[') {

                    queue.Dequeue();

                    list.Add(ParseList(queue));

                } else {

                    queue.Dequeue();

                }

            }

            if (queue.Count > 0) {

                queue.Dequeue();

            }

            return list;

        }

    }
    
}
