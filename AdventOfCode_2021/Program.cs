using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode_2021 {
    class Program {
        static void Main(string[] args) {

            /*
            SonarSweep_01 sonar = new SonarSweep_01();
            Console.WriteLine(sonar.getNumberOfIncreases());
            */
            SonarSweep_02 sonar = new SonarSweep_02();
            Console.WriteLine(sonar.GetNumberOfIncreases());

            Console.ReadLine();

            }
        }

    }
