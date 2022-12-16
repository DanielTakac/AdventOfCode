using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13 {

    public static class Packets {

        public static int CompareElements(object first, object second) {

            // Returns 1 if first > second, 0 if first == second, -1 if first < second

            if (first is int && second is int) {

                if ((int)first > (int)second) {

                    return 1;

                } else if ((int)first == (int)second) {

                    return 0;

                } else {

                    return -1;

                }

            } else if (first is int && second is not int) {

                List<object> firstAsList = new List<object>() { first };
                
                return CompareLists(firstAsList, (List<object>)second);

            } else if (first is not int && second is int) {

                List<object> secondAsList = new List<object>() { second };

                return CompareLists((List<object>)first, secondAsList);

            } else {

                return CompareLists((List<object>)first, (List<object>)second);

            }

        }

        public static int CompareLists(List<object> first, List<object> second) {

            // Returns 1 if first > second, 0 if first == second, -1 if first < second

            int maxIx = Math.Min(first.Count, second.Count);

            for (int i = 0; i < maxIx; i++) {

                object element1 = first[i];
                object element2 = second[i];

                int comparison = CompareElements(element1, element2);

                if (comparison > 0) {

                    return 1;

                } else if (comparison < 0) {

                    return -1;

                }

            }

            if (first.Count > second.Count) {

                return 1;

            } else if (first.Count == second.Count) {

                return 0;

            } else {

                return -1;

            }

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

                        if (i != list.Count - 1) packet += ",";

                    }

                    packet += "]";

                    return packet;

                }

                return StringifyNestedList(objects);

            }

        }

    }

}
