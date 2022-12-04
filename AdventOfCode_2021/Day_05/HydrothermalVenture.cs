using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

struct Coordinate {
    public int x;
    public int y;

    public Coordinate(int x, int y) {
        this.x = x; this.y = y;
        }
    }

namespace AdventOfCode_2021 {
    class HydrothermalVenture {

        int[,] hydrothermalVentures = new int[1000, 1000];
        public int GetHydrothermalVentureGroupCount(string input) {
            LoadAndProcessInput(input);
            return GetVenturesGroupCount();
            }

        private void LoadAndProcessInput(string path) {
            
            int[] matchesValues = new int[4];
            int i = 0;

            string pattern = @"\d*";

            foreach (string line in File.ReadLines(path)) {
                try {
                    Match match = Regex.Match(line, pattern, RegexOptions.None, TimeSpan.FromSeconds(1));
                    i = 0;

                    // Handle match here...
                    while (match.Success) {
                        if(match.Value != "") {
                            matchesValues[i] = Convert.ToInt32(match.Value);
                            i++;
                            }
                        match = match.NextMatch();
                        }
                    FindLineOfVents(new Coordinate(matchesValues[0], matchesValues[1]), new Coordinate(matchesValues[2], matchesValues[3]));
                    }
                catch (RegexMatchTimeoutException) {
                    // Do nothing: assume that exception represents no match.
                }
                //Console.WriteLine();
            }
        }

        private void FindLineOfVents(Coordinate A, Coordinate B) {

            Coordinate start; Coordinate end;

            // HydrothermalVenture part 02
            if (Math.Abs(A.x - B.x) == Math.Abs(A.y - B.y)) {
                if (A.x < B.x) { start = A; end = B; }
                else { start = B; end = A; }

                if(start.x < end.x && start.y < end.y)
                    for (int i = start.x, j = start.y; i <= end.x; i++, j++)
                        hydrothermalVentures[i, j]++;
                else
                    for (int i = start.x, j = start.y; i <= end.x; i++, j--)
                        hydrothermalVentures[i, j]++;
                }
            // HydrothermalVenture part 01
            else if (A.x == B.x || A.y == B.y) {
                if (A.x < B.x || A.y < B.y) { start = A; end = B; }
                else { start = B; end = A; }

                for (int i = start.x; i <= end.x; i++)
                    for (int j = start.y; j <= end.y; j++)
                        hydrothermalVentures[i, j]++;
                }
            }

        private int GetVenturesGroupCount() {
            int venturesGroupCount = 0;

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    if(hydrothermalVentures[i, j]> 1) venturesGroupCount++;
            
            return venturesGroupCount;
            }
        }
}
