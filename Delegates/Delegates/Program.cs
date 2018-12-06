using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Object initilization syntax
            // If no parantheses after MoviePlayer, zero-arguments constructor "()" is assumed
            var player = new MoviePlayer
            {
                CurrentMovie = "Lord of the Rings: The Fellowship of the Ring - Extended Edition"
            };

            // The function must have a compatible signature with the delegate of the event
            MoviePlayer.MovieFinishedStringHandler handler = EjectDisc;

            // Subscribe to events with +=
            player.MovieFinished += handler;

            // Unsubscribe to events with -=
            // player.MovieFinished -= handler;

            // When C# got generics, they added Func and Action class generic classes, and we can use these in stead of delegate types.

            // Action is for void-return, func is for non-void return
            Action<string> handler2 = EjectDisc;

            // player.MovieFinished += handler2;

            player.PlayMovie();
        }

        static void EjectDisc(string title)
        {
            Console.WriteLine($"-Ejecting disc {title}-");
        }
        // Having two methods with the same name but different arguments is allowed; this is called method overloading
        // C# can tell which method you mean by what arguments you give it when you try to call it


        static void Linq()
        {
            var x = new List<string>();

            // I want to know the max length of those strings
            int longestLength = x.Max(s => s.Length);

            // LINQ methods we should know:
            //  > Select (a mapping operation, will take each element and change it into something else)
            var firstCharacters = x.Select(s => s[0]);
            //  > Average, Min, Max
            //  > All (expects a boolean-returning lambda, checks that all elements meet some condition)
            bool allShorterThan5Char = x.All(s => s.Length < 5);
            //  > Any (works like All, but return true if there's ANY mathc, not just ALL matches)
            //  > Where (filters the sequence for only the elements that return true)
            var onlyTheLongElements = x.Where(s => s.Length > 20);

            // You can also chaing these together
            bool b = x.Where(s => s.Length > 20)
                      .Select(s => s[0])
                      .All(c => c == 'a' || c == 'b');
            // b will return true if every long element starts with 'a' or 'b'

            // Remember, LINQ uses "deferred execution", meaning it doesn't actuall "run the loop" until you need the result
            List<char> listOfChars = firstCharacters.ToList();
            //

        }

        static void Finally()
        {
            try
            {
                // This code always runs
                Console.WriteLine("try");
                // Until an exception in here

                // If I'm opening resoucred that need to be cleaned up/closed, don't put cleanup code at the end of the try block because an expection beforehand might skip it
            }
            catch(ArgumentException e)
            {
                // This code runs when there is a matching exsception from insdie the try block
                
                // Only put ArgumentException-specific cleanup here
            }
            finally
            {
                // This code always runs, even if there was an uncaught exception in the try block

                // Put general cleanup of "try" block resources here
            }
            // Don't put cleanup code here either, because uncaught excpetions will skip it (for being outside the "finally" block)

            // We can even have "try" and "finally" without a "catch" block
            // If you are using resource that you must clean up, but any error really still needs to propagate up becuase you can't actuall handle it.
            // There is a "using" block (not the Using statement at top of the file) syntax that can replace the try-finally block(s)
        }
    }
}
