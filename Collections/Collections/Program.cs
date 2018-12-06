using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
            Sets();
            StringEquality();
            Dictionaries();
        }

        static void Arrays()
        {
            // Arrays are the same as they are in any language: a FIXED length (not dynamic, cannot change) row of slots for some (common?) type
            // Undefined values in arrays default to whatever the default value for the type is

            int[] intArray = new int[10];
            Console.WriteLine(intArray[5]);

            // Iterate over arrays with regular loop or foreach
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
                Console.WriteLine();
            }

            Console.WriteLine("------------");
            Console.WriteLine();

            // Iterate when you don't need the index
            foreach(var item in intArray)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            // Foreach loop can be uses with anything that omplements the IEnumerable interface (also used with LINQ)

            // Array initialization syntax, length inferred
            int[] array = new int[]
            {
                4, 6, 8, 25, 5, 6 
            };


            // Jagged/nested arrays
            int[][] arrayOfFourArrays = new int[4][];
            // This is now an array of four nulls
            // Console.WriteLine(arrayOfFourArrays[0][0]); //exception

            arrayOfFourArrays[0] = new int[3];

            // Multi-dimensional arrays
            int[,] trueMtuliDArray = new int[5, 5];
            // This is an array with 25 zeroes that we instead with rows and columns
            trueMtuliDArray[3, 4] = 5;
            // Generally use multi-dimensional arrays instead of jagged arrays
            //  Also, use generic collection classes for everything that's not some performance-critical loop

            // Never pre-omptimize your code, write it in the simple/understandable way first, and if neccessary, profile it later and optimize where actually useful
        }

        static void Lists()
        {
            // Better practice to use lists instead of arrays
            var list = new List<bool>();
            // IList <bool> list = new List<bool>(); also works
            // ISet, IDictionary, and ICollection(?) also work

            // Depending on abstractions, not concretions; i.e. on interfaces, not concrete implementations/classes so the actual class should be swapped out laster easily
            // More of a big deal for method signatures ( parameeteres, return types), less so for local vaiables like this but sitll goos practice.

            list.Add(true);
            list.Add(true);
            list.Add(false);

            // Lists have dynamic length, can grow and shrink as you add and remove values

            var list2 = new List<bool>() { false, false, true };
            list2.AddRange(list); // Add a range

            var x = list2[2];  // Lists can be indexed just like arrays
            list[1] = true;
        }

        static void Sets()
        {
            // Sets have no particular order to them and do not allow allow duplicates, adding an element that's already is there has zero effect (doesn't happen, doesn't throw an error/exception)
            // Based on the mathematical concept of set, having standard "operations" like union, intersection, and difference.  Also has comparisons like subset
            // Sets are very fast to search for a specific value, even if there's millions of thing in the set because it's implemented with a "hashtable"
            // Slower to iterate over than list, but faster to lookup
            var set = new HashSet<string>();


            set.Add("abc");
            set.Add("abc");  // This does nothing
            set.Add("def");

            Console.WriteLine(set.Count);  // Prints 2
        }

        static void StringEquality()
        {
            // In some languages, "==" always means "references the same object in memory", while .Equals() is for "references an EQUIVALENT obeject"
            // In C#, using "==" on strings compares value, not reference.  Operator overloading exists in C# (though it's not used much) and "==" can be overrideen to do value comparison on classes too.
            // For basically all other references types, "==" checks if they are the exact same object
        }

        static void Dictionaries()
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Germany", "Berlin");
            dict.Add("USA", "Washington, DC");

            // You can use indexing syntax on dictionaries too
            Console.WriteLine(dict["USA"]);  // Prints Washington, DC

            dict["Mexico"] = "Mexico City";  // Inserts/overwrites

            // Dictionary initialization syntax
            var dict2 = new Dictionary<string, string>
            {
                { "Germany", "Berlin" },
                { "USA", "Washington, DC" }
            };

            // Ways of using foreach with dictionaries
            foreach (string key in dict.Keys) { }
            foreach (string value in dict.Values) { }
            foreach (KeyValuePair<string, string> pair in dict) ;
        }
    }
}
