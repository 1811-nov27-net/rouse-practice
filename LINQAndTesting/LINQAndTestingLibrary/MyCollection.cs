using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAndTestingLibrary
{
    /// <summary>
    ///     A list with some extra helper methods
    /// </summary>
    /// <remarks>
    ///     Two strategiew we could use to leverage the built-in collection classes:
    ///     -  Inheritance (MyCollection IS a list)
    ///     -  Composition (MyCollection HAS a list)
    /// </remarks>
    public class MyCollection : MyGenericCollection<string>
    {
       
        // Don't needs this since we're extending MyGenericCollection
        // "readonly" just means I can't reassign "_list" to a different object later, it doesn't mean it can't be modified with its methods
        private readonly List<string> _list = new List<string>();

        // Every class has at least one constructor; if you don't define one, it has a default constructor without any parameters: "public MyCollection() {}"...
        // ...but as soon as you define any constructor, that default one will not be added

        public void Sort()
        {
            _list.Sort();
        }

        public override void Add(string item)
        {
            _list.Add(item);
        }

        // Property without a "set"
        // Calling code can say "coll.Length" instead of coll.GetLength()
        public int Length()
        {
            return _list.Count;
        }

        public object Longest()
        {
            int indexOfLongest = -1;
            string longest = null;
            foreach (var item in _list)
            {
                if (item != null && item.Length > indexOfLongest)
                {
                    indexOfLongest = item.Length;
                    longest = item;
                }
            }
            return longest;
        }

        public double AverageLength()
        {
            // Much nicer than a manual loop and less error-prone
            return _list.Average(x => x.Length);
        }

        // Return number of elements that start with 'a'
        public int NumberOfAs()
        {
            return _list.Count(x => (x.Length > 0 && x[0] == 'a'));

            // Lambda expressions are like methods, but you can pass them as parameters and assign them to variables
        }

        private static bool ContainsVowel(string s)
        {
            // Lambda expressions are convertible to "Func" or "Action" types, so they can be assigned to variables like this:
            Func<char, bool> isVowel = (x => "AEIOUaeiou".Contains(x));

            // True if, for ANY element, that...
            return s.Any(
                // ...the element is contained in this string of vowels
                isVowel
            );
        }

        public int NumberWithVowels()
        {
            return _list.Count(ContainsVowel);
        }

        // LINQ (and IEnumerable) uses deferred execution

        // Returns first memebet in sorted order
        public string FirstAlphabetical()
        {
            // OrderBy will sort the sequence by some 'key'; "x => x" means sort the strings using regular string sort
            IEnumerable<string> sorted = _list.OrderBy(x => x);
            // We actually haven't sorted the list in any way or iterated over it yet, only set up how we will iterate when we need the values
            var first = sorted.First();
            // This method call actuall runs the sort, then discards everything but the first entry.
            return first;
        }
    }
}
