using System;
using static System.Console;

namespace TestScore01Old
{
    internal class Program
    {
        //  Global Constant
        const int ARRAYSIZE = 25;           //  25 test scores
        const int PASSING   = 60;           //  Pass/fail limit          

        //  Global Variables
        static Random rand      = new Random();
        static int[] testScores = new int[ARRAYSIZE];
        public static void Main(string[] args)
        {
            //  Fill testScores array with 25 random numbers
            fillArray();

            //  Display testScores array in original order
            displayTestScoresArray();

            //  Sort testScores in ascending order and display
            ascSortAndDisplayTestScoresArray();

            //  Sort testScores in descending order and display
            descSortAndDisplayTestScoresArray();

            //  Find passing testScores (>= 60) and display
            calculateAndDisplayPassingScores();

            ReadLine();
        }

        static void fillArray()
        {
            //  Create 25 random numbers between 25 and 100
            //  and put them in the int testScores array.
            for (int lcv = 0; lcv < ARRAYSIZE; ++lcv)
            {
                testScores[lcv] = rand.Next(0, 101);
            }
        }

        static void displayTestScoresArray()
        {
            //  Display testScores array
            Write("testScores array in unsorted order:\t");
            foreach (var ts in testScores)
            {
                Write(" " + ts.ToString());
                //Write(" {0}", ts);
            }

            WriteLine("");
        }

        static void ascSortAndDisplayTestScoresArray()
        {
            //  Sort the testScores array values in ascending order.
            Array.Sort(testScores);

            //  Display sorted ascending testScore array elements
            Write("\nTestScores array, sorted ascending:\t");
            foreach (var ts in testScores)
            {
                Write(" {0}", ts);
            }
        }

        static void descSortAndDisplayTestScoresArray()
        {
            //  Sort the testScores array values in descending order.
            Array.Reverse(testScores);

            //  Display sorted descending testScore array elements
            Write("\n\nTestScores array, sorted descending:\t");
            foreach (var ts in testScores)
            {
                Write(" {0}", ts);
            }
        }

        static void calculateAndDisplayPassingScores()
        {
            string passing = "";
            for (int lcv = 0; lcv < ARRAYSIZE; ++lcv)
            {
                if (testScores[lcv] >= PASSING)
                {
                    passing += testScores[lcv] + " ";
                }
            }

            //Display filtered scores
            WriteLine("\n\nPassing Scores in testScores array:\t " + passing);
        }
    }
}
