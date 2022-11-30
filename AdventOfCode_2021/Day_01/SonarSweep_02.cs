using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class SonarSweep_02 {
        public int GetNumberOfIncreases() {
            LoadInput();
            int totalIncreases = 0;
            int i = 0;
            for (; i+1 < sumsCount; i++){
                totalIncreases += CheckIncreas(sums[i], sums[i+1]);
            }
            return totalIncreases;
        }

        private int[] sums = new int[2000];
        private int sumsCount = 0;
        private void LoadInput() {
            try {
                using (StreamReader sr = new StreamReader("../../Day_01/input.txt")) {
                    string line;
                    int first = Convert.ToInt32(sr.ReadLine());
                    int second = Convert.ToInt32(sr.ReadLine());
                    int third = 0;
                    sumsCount = 0;
                    
                    while ((line = sr.ReadLine()) != null) {
                        third = Convert.ToInt32(line);
                        sums[sumsCount] = first + second + third;
                        Console.WriteLine($"i: {sumsCount}, SUMA: {sums[sumsCount]}, number: {third}");
                        first = second;
                        second = third;
                        sumsCount++;
                        }
                }
            }
            catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private int CheckIncreas(int lastSweep, int actualSweep) {
            if (actualSweep > lastSweep) return 1;
            return 0;
        }
    }
}



 
