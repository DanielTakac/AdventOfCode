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

        public static string ListToString(List<object> objects) {

            if (objects.Count == 0) {

                return "[]";

            } else if (objects.Count == 1 && objects[0] is int) {

                return $"[{objects[0]}]";

            } else {

                string StringifyNestedList(List<object> list) {

                    string packet = string.Empty;

                    packet += "[";

                    for (int i = 0; i < list.Count; i++) {

                        if (list[i] is int) {

                            packet += list[i];

                        } else {

                            packet += StringifyNestedList((List<object>)list[i]);

                        }

                        if (i != list.Count - 1)
                            packet += ",";

                    }

                    packet += "]";

                    return packet;

                }

                return StringifyNestedList(objects);

            }

        }

    }
    
}
