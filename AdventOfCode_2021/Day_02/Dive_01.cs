using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class Dive_01 {

        public int GetMultiply() {
            LoadInput();
            return horizontal * depth;
        }
        private int horizontal = 0;
        private int depth = 0;

        private void LoadInput() {
            try {
                using (StreamReader sr = new StreamReader("../../Day_02/input.txt")) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        string[] subs = line.Split(' ');
                        Console.WriteLine($"where: {subs[0]}, number: {subs[1]}");
                        SaveDirection(subs[0], Convert.ToInt32(subs[1]));
                        }
                    }
                }
            catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                }
            }

        private void SaveDirection(string direction, int value) {

            switch (direction) {
                case "forward":
                    horizontal += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
                default: break;
            }
        }
    }
}
