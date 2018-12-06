using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        // C# supports some things call delegatres and events.  The idea here is, I can write a class that expects its consumer to actually "inject" behavior into it for it to use

        // This enables some polymorphism; hyou can write classes that support a lot of different behaviors to be decided by other code.
        public string CurrentMovie { get; set; }

        // This delegate type can hold any function with zero parameters/arguments and void return
        public delegate void MovieFinishedHandler();

        // Now, any variable of type "MovieFinishedHandler" can hold zero-argument functions with void return

        // An event is something you can subscribe to with any number of functions
        // When the event is "called" as if it itself were a function, all subscribing functions are called

        // You NEED a delegate type to declare the event, and all subscribing functions must match that signature
        // Event delegates should always be a void-returning type
        public event MovieFinishedStringHandler MovieFinished;
        // public event Action<string> MovieFinished;

        public delegate void MovieFinishedStringHandler(string title);

        public void PlayMovie()
        {
            Thread.Sleep(3000);  // Wait for 3 seconds

            Console.WriteLine($"Finished movie {CurrentMovie}");

            // We'll fire an event when the movie's finished, and any code using this movie player can subscribe to that event with whatever function/code they want

            //Have to check that events are not null before firing them; events without without ANY subscribers are == null
            if (MovieFinished != null)
            {
                // When you call an event that needs argument, the arguments will go to the subscribing functions
                MovieFinished(CurrentMovie);
            }

            // Or, use null conditional operator
            // "?." does a null check on the left-hand side first and left the left hand side is null, it does nothing
            // MovieFinished?.Invoke();
            
        }
    }
}
