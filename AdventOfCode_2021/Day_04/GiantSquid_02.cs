using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021 {
    class GiantSquid_02 {

        public int GetWinnerTicket() {
            LoadInput();
            FindLastWinnerTicket();
            return GetScoreOfWinnerTicket(lastWinnerBoard, lastNumber);
            }

        int lastNumber = 0;
        int[,] lastWinnerBoard = new int[6,6];
        int [] bingoNumbers;
        List<int [,]> boards = new List<int[,]>();
        List<int[]> numbersOnBoards = new List<int[]>();

        private int GetScoreOfWinnerTicket(int [,] ticket, int lastNumber) {

            int sum = 0;

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    sum += ticket[i, j];
                    }
                }

            return sum*lastNumber;
        }

        private void FindLastWinnerTicket() {

            // do for each drawn bingo number
            foreach (int number in bingoNumbers) {
                int board = 0;
                bool isWinner;
                // check each ticket, if it contains this numer 
                for (; board < numbersOnBoards.Count(); board++) {
                    if (numbersOnBoards[board].Contains(number)) {
                        isWinner = false;
                        for (int i = 0; i < 5; i++) {
                            if (isWinner) break;
                            for (int j = 0; j < 5; j++) {
                                // if contains the number, set this number to zero and increase end of row and column
                                if (boards[board][i, j] == number) {
                                    boards[board][i, j] = 0;
                                    boards[board][i, 5]++;
                                    boards[board][5, j]++;
                                    // check if this is a winner ticket
                                    if (boards[board][i, 5] == 5 || boards[board][5, j] == 5) {
                                        lastWinnerBoard = boards[board];
                                        boards.RemoveAt(board); 
                                        numbersOnBoards.RemoveAt(board);
                                        board--;
                                        lastNumber = number;
                                        isWinner = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
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
