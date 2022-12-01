using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode_2021 {
    class Program {
        static void Main(string[] args) {

            //SonarSweep_02 sonar = new SonarSweep_02();
            //Console.WriteLine(sonar.GetNumberOfIncreases());

            //Dive_02 dive = new Dive_02();
            //Console.WriteLine(dive.GetMultiply());

            BinaryDiagnostic_02 diagnostic = new BinaryDiagnostic_02();
            Console.WriteLine(diagnostic.GetLifeSupportRating()); 

            Console.ReadLine();
            }
        }
    }
