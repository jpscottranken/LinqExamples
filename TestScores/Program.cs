using System;
using System.Linq;
using static System.Console;

namespace TestScores
{
    internal class Program
    {
        //  Global Constant
        const int ARRAYSIZE = 25;           //  25 test scores
        const int PASSING = 60;             //  Pass/fail limit 

        //  Global Variables
        static Random rand       = new Random();
        static int[]  testScores = new int[ARRAYSIZE];
        public static void Main(string[] args)
        {
            //  Fill testScores array with 25 random numbers
            fillArray();

            //  Display testScores array
            linqQueryToDisplayTestScoresInOriginalArray();

            //  LINQ query to sort & display testScores array ascending
            linqQueryToCalculateAndDisplayTestScoresAscending();

            //  LINQ query to sort & display testScores array descending
            linqQueryToCalculateAndDisplayTestScoresDescending();

            //  LINQ query to sort & display testScores passing (>= 60)
            linqQueryToCalculateAnDisplayTestScoresPassing();

            //  LINQ query to sort & display testScores passing (>= 60)
            //  in descending order
            linqQueryToCalculateAnDisplayTestScoresPassingDescending();

            ReadLine();

        } // end Main

        static void fillArray()
        {
            //  Create 25 random numbers between 0 and 100
            //  and put them in the int testScores array.
            for (int lcv = 0; lcv < ARRAYSIZE; ++lcv)
            {
                testScores[lcv] = rand.Next(0, 101);
            }
        }

        static void linqQueryToDisplayTestScoresInOriginalArray()
        {
            //  Display original array
            //Write("testScores array in unsorted order:\t");
            //foreach (var ts in testScores)
            //{
            //    Write(" {0}", ts);
            //}

            //WriteLine("");

            //  LINQ query to display testScores
            //  array values in original order.
            //  SELECT * FROM testScores
            var originalOrder =
               from ts in testScores
               select ts;

            //  Display sorted ascending testScore array elements
            Write("\nTestScores array in original order:\t");
            foreach (var element in originalOrder)
            {
                Write(" {0}", element);
            }

            WriteLine("");
        }

        static void linqQueryToCalculateAndDisplayTestScoresAscending()
        {
            //  LINQ query with orderby clause to sort testScores
            //  array values in ascending order.
            var testScoresAscending =
               from ts in testScores
               orderby ts ascending
               select ts;

            //  Display sorted ascending testScore array elements
            Write("\nTestScores array, sorted ascending:\t");
            foreach (var element in testScoresAscending)
            {
                Write(" {0}", element);
            }
        }

        static void linqQueryToCalculateAndDisplayTestScoresDescending()
        {
            //  LINQ query with orderby clause to sort testScores
            //  array values in descending order.
            var testScoresDescending =
               from ts in testScores
               orderby ts descending
               select ts;

            //  Display sorted descending testScore array elements
            Write("\n\nTestScores array, sorted descending:\t");
            foreach (var element in testScoresDescending)
            {
                Write(" {0}", element);
            }
        }

        static void linqQueryToCalculateAnDisplayTestScoresPassing()
        {
            //  LINQ query that obtains values greater than or equal to 60 (passing)
            var filtered =
               from ts in testScores
               where ts >= PASSING
               select ts;

            //  Display filtered scores
            Write("\n\nPassing Scores in testScores array:\t");
            foreach (var element in filtered)
            {
                Write(" {0}", element);
            }
        }

        static void linqQueryToCalculateAnDisplayTestScoresPassingDescending()
        {
            //  Show all passing testScores in descending order
            var sortedFilteredResults =
            from ts in testScores
            where ts >= PASSING
            orderby ts descending
            select ts;

            // display the sorted results
            Write("\n\nPassing testScores in Descending Order:\t");
            foreach (var element in sortedFilteredResults)
            {
                Write(" {0}", element);
            }
        }

    }
}
