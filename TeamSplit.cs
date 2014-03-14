using System;
using System.Collections.Generic;

namespace TeamSplit
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlayers = 0;
           
            Console.WriteLine("Enter the number of test cases: ");
            numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            IList<Strength> playerStrength = new List<Strength>();
            
            for (int counter = 0; counter < numberOfPlayers; counter++) 
            {
                Console.WriteLine("\nAdd Player Strength: ");
                Strength str = new Strength();
                Console.WriteLine("\nEnter N: ");
                str.N = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter a: ");
                str.a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter b: ");
                str.b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter c: ");
                str.c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter d: ");
                str.d = Convert.ToInt32(Console.ReadLine());
                playerStrength.Add(str);
                double[] calculatedStrength = new double[100];
                for (var innerCounter = 0; innerCounter < str.N; innerCounter++)
                {
                    if (innerCounter == 0)
                    {
                        calculatedStrength[innerCounter] = str.d;
                    }
                    else
                    {
                        calculatedStrength[innerCounter] = (str.a * Math.Pow(calculatedStrength[innerCounter - 1], 2)) + (str.b * calculatedStrength[innerCounter - 1]) + str.c;
                    }
                }
                PrintAbsDiff(calculatedStrength);
            }
        }


        public static void PrintAbsDiff(double[] strengthArray)
        {
            double totTeam1 = 0;
            double totTeam2 = 0;
            Console.WriteLine("\nSee the output");
            for (int counterStr = 0; counterStr < strengthArray.Length; counterStr++)
            {
                if ((counterStr % 2) == 1)
                {
                    totTeam1 += strengthArray[counterStr];
                }
                else
                {
                    totTeam2 += strengthArray[counterStr];
                }
            }

            if (Math.Abs(totTeam1 - totTeam2) > 0)
            {
                Console.WriteLine(Math.Abs(totTeam1 - totTeam2));
            }
            Console.ReadLine();
        }
    }

    public class Strength
    {
        public int N { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }
    }
}
