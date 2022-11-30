﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class SonarSweep {
        public int getNumberOfIncreases() {
            loadInput();
            int actualSweep = 0;
            int totalIncreases = -1;

            foreach(int sweep in deeps) {
                totalIncreases += checkIncreas(actualSweep, sweep);
                actualSweep = sweep;
                }
            return totalIncreases;
        }

        private int[] deeps = new int[2000];
        private void loadInput() {
            try {
                using (StreamReader sr = new StreamReader("../../Day_01/input.txt")) {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null) {
                        deeps[i] = Convert.ToInt32(line);
                        Console.WriteLine(deeps[i]);
                        i++;
                        }
                    }
                }
            catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        private int checkIncreas(int lastSweep, int actualSweep) {

            if (actualSweep > lastSweep) return 1;
            return 0;
            }
        }
}
