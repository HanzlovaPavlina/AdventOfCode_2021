using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class BinaryDiagnostic_01 {

        public int GetPowerConsumption() {
            LoadInput();
            GetRates();
            Console.WriteLine($"gama rate: {gamaRate}, epsilon rate: {epsilonRate}");
            return gamaRate*epsilonRate;
        }
        private string inputPath = "../../Day_03/input.txt";
        private int[] zerosCount = new int [12];
        private int[] onesCount = new int [12];
        private int gamaRate;
        private int epsilonRate;

        private void LoadInput() {
            try {
                using (StreamReader sr = new StreamReader(inputPath)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        for(int i = 0; i < line.Length; i++) {
                            if (line[i] == '0') zerosCount[i]++;
                            else onesCount[i]++;
                            //Console.WriteLine($"sign: {line[i]}, zeros[{i}]: {zerosCount[i]}, ones[{i}]: {onesCount[i]}");
                            }
                        }
                    }
                }
            catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void GetRates() {
            string gamaBin = "";
            string epsilonBin = "";

            for (int i = 0; i < zerosCount.Length; i++) {
                if(zerosCount[i] > onesCount[i]) {
                    gamaBin = gamaBin.Insert(gamaBin.Length, "0");
                    epsilonBin = epsilonBin.Insert(epsilonBin.Length, "1");
                }
                else {
                    gamaBin = gamaBin.Insert(gamaBin.Length, "1"); 
                    epsilonBin = epsilonBin.Insert(epsilonBin.Length, "0");
                }
            }
            Console.WriteLine($"gama binary: {gamaBin}, epsilon binary: {epsilonBin}");
            gamaRate = Convert.ToInt32(gamaBin, 2);
            epsilonRate = Convert.ToInt32(epsilonBin, 2);
        }
    }
}
