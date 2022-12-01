using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class BinaryDiagnostic_02 {

        public int GetLifeSupportRating() {
            LoadInput();
            gamaRate = GetFinalRating(oxygenGeneratorValues, true);
            epsilonRate = GetFinalRating(CO2ScrubberValues, false);
            Console.WriteLine($"gama rate: {gamaRate}, epsilon rate: {epsilonRate}");
            return gamaRate*epsilonRate;
        }
        private string inputPath = "../../Day_03/input.txt";
        private string[] oxygenGeneratorValues;
        private string[] CO2ScrubberValues;
        private int gamaRate;
        private int epsilonRate;

        private void LoadInput() {
            int oneCount = 0, zeroCount = 0;
            string[] ones = new string[1000];
            string [] zeros = new string[1000];

            foreach (string line in File.ReadLines(inputPath)) {
                if(line[0] == '1') {
                    ones[oneCount] = line;
                    oneCount++;
                }
                else {
                    zeros[zeroCount] = line;
                    zeroCount++;
                }
            }
            Array.Resize(ref ones, oneCount);
            Array.Resize(ref zeros, zeroCount);

            if (oneCount > zeroCount) {
                oxygenGeneratorValues = ones;
                CO2ScrubberValues = zeros;
            }
            else {
                oxygenGeneratorValues = zeros;
                CO2ScrubberValues = ones;
            }
        }

        private string[] SelectValues(int position, string[] values, bool maxCount) {
            string[] ones = new string[1000]; int oneCount = 0;
            string[] zeros = new string[1000]; int zeroCount = 0;
            string[] keptValues = new string[1000];

            foreach (string value in values) {
                if (value[position] == '1') {
                    ones[oneCount] = value;
                    oneCount++;
                    }
                else {
                    zeros[zeroCount] = value;
                    zeroCount++;
                }
            }
            Array.Resize(ref ones, oneCount);
            Array.Resize(ref zeros, zeroCount);
            return (maxCount ? (oneCount >= zeroCount ? ones : zeros) : (oneCount < zeroCount ? ones : zeros));
        }

        private int GetFinalRating(string [] values, bool oxygenGenerator) {
            while (values.Length > 1) {
                for (int i = 1; i < 12; i++) {
                    values = SelectValues(i, values, oxygenGenerator);
                    if (values.Length == 1) break;
                }
            }
            return Convert.ToInt32(values[0], 2);
        }


        
    }
}
