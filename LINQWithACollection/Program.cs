using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Console;

namespace LINQWithACollection
{
    internal class Program
    {
        //  Besed loosely off of the following URL:
        //  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections

        static List<string> fish = new List<string>();
        
        static void Main(string[] args)
        {
            fillFishListAndDisplay();

            //linqQueryToFindFishWithFishInTheirName();

            //linqQueryToShowFishNamesInUpperCase();

            //linqQueryToShowFishNamesThatStartWithAnS();

            //linqQueryToShowFishNamesThatEndWithAnNorH();

            ReadLine();
        }

        static void fillFishListAndDisplay()
        {
            fish.Add("guppy");
            fish.Add("goldfish");
            fish.Add("carp");
            fish.Add("catfish");
            fish.Add("trout");
            fish.Add("sunfish");
            fish.Add("northern");
            fish.Add("salmon");
            fish.Add("swordfish");
            fish.Add("pike");
            fish.Add("trout");
            fish.Add("mackerel");

            var allFish =
               from f in fish
               select f;

            //Display all fish
            foreach (var f in allFish)
            {
                WriteLine(f);
            }
        }

        static void linqQueryToFindFishWithFishInTheirName()
        {
            var fishInName =
                from f in fish
                where f.Contains("fish")
                orderby f
                select f;

            //  Display fish with the word "fish" in their name
            foreach (var f in fishInName)
            {
                WriteLine(f);
            }
        }

        static void linqQueryToShowFishNamesInUpperCase()
        {
            WriteLine("Fish Names in UPPER Case:");
            foreach (var f in fish)
                WriteLine(f.ToUpper());
        }

        static void linqQueryToShowFishNamesThatStartWithAnS()
        {
            var startsWithS =
                from f in fish
                where f.ToUpper().StartsWith("S")
                orderby f
                select f;

            WriteLine("Fish Names that start with 'S':");
            foreach (var f in startsWithS)
                WriteLine(f.ToUpper());
        }

        static void linqQueryToShowFishNamesThatEndWithAnNorH()
        {
            var endsWithNorH =
                from f in fish
                where f.ToUpper().EndsWith("N") ||
                      f.ToUpper().EndsWith("H") 
                orderby f
                select f;

            WriteLine("Fish Names that end with 'N' or 'H':");
            foreach (var f in endsWithNorH)
                WriteLine(f.ToUpper());
        }

    }
}
