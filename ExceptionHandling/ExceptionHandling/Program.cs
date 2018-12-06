using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceptions are runtime errors that we can potentially handle; they are also objects and defined by classes like anything else.

            try
            {
                // Try goes around code that is expected to throw an exception

                var x = 4;
                var y = x / 0;

                Console.WriteLine("never prints because we will throw an exception");

                // You can throw exceptions yourself with a throw statement
                // throw new ArgumentNullException();
                // Throw statements are most useful when you're going to handle an exception later in the program (versus immediately after ebing caught)
            }
            // Exceptions must be of the right type.  For example, the DivideByZeroException below will never catch exceptions thrown by attempting an invalid typecast of a variable
            catch (DivideByZeroException e)
            {
                Console.WriteLine("divided by zero, moving on...");
                // After the catch of the catch block, program continues to execute as normal

                // throw; here would re-throw the current exception
            }

            // It's consdiered bad form to attempt to catch the general Excpetion type
            // List exceptions from most specific order to least specific order

            

            Console.WriteLine("The program continues!");
        }

        static void BadCode()
        {

        }
    }
}
