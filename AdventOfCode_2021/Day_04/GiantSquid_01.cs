using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class GiantSquid_01 {

        public int GetWinnerTicket() {
            LoadInput();
            FindWinnerTicket();
            return GetScoreOfWinnerTicket(winnerTicket, lastNumber);
            }

        int lastNumber = 0;
        int winnerTicket = 0;
        int [] bingoNumbers;
        List<int [,]> boards = new List<int[,]>();
        List<int[]> numbersOnBoards = new List<int[]>();

        private int GetScoreOfWinnerTicket(int ticketNumber, int lastNumber) {

            int sum = 0;

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    sum += boards[ticketNumber][i, j];
                    }
                }

            return sum*lastNumber;
        }

        private void FindWinnerTicket() {
            
            foreach(int number in bingoNumbers) {
                int board = 0;

                foreach (int[] numbersOnBoard in numbersOnBoards) {
                    if (numbersOnBoard.Contains(number)) {
                        // TODO prohledat 2D pole, zadat na posledni pozice info, zkontrolovat, jestli neni rada nebo sloupec
                        for (int i = 0; i < 5; i++) {
                            for (int j = 0; j < 5; j++) {
                                if (boards[board][i, j] == number) {
                                    boards[board][i, j] = 0;
                                    boards[board][i, 5]++;
                                    boards[board][5, j]++;
                                    if (boards[board][i, 5] == 5 || boards[board][5, j] == 5) {
                                        winnerTicket = board;
                                        lastNumber = number;
                                        return;
                                        }
                                }
                            }
                        }
                    }
                    board++;
                }
            }
        }

        private void LoadInput() {

            try {
                using (StreamReader sr = new StreamReader("../../Day_04/input.txt")) {

                    bingoNumbers = sr.ReadLine().Split(',').Select(Int32.Parse).ToArray(); ;

                    string line;
                    int[] nextRow;

                    while ((line = sr.ReadLine()) != null) {

                        boards.Add(new int[6, 6]);
                        numbersOnBoards.Add(new int[25]);
                        int i = 0, row = 0;

                        for(int x = 0; x < 5; x++) {
                            line = sr.ReadLine();

                            int col = 0;
                            string replacedLine = line.Replace("  ", " ").TrimStart(); 
                            nextRow = replacedLine.Split(' ').Select(Int32.Parse).ToArray();
                            foreach (int number in nextRow) {
                                numbersOnBoards.Last()[i] = number;
                                boards.Last()[row,col] = number;
                                col++; i++;
                                //Console.WriteLine($"{number} ");
                            }
                            //Console.WriteLine();
                            row++;
                        }
                        Array.Sort(numbersOnBoards.Last());
                        //foreach (int number in numbersOnBoards.Last()) Console.Write($"{number} ");
                        //Console.WriteLine();
                    }
                }
            }
            catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                }

            }
        }
    }
