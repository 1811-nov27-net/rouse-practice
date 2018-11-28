using System;
using System.Collections.Generic;

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Local variables and types
            int x = 0;
            double y = 4.58; // allows decimal - 64-bit float
            decimal z = 5.001m; // even more precision - for financial programs, etc.

            string s = "Hello my baby, hello my honey, hello my ragtime gal!";
            bool b = true; // true/false declarations are lower-case, upper-case will not work

            // base class of *everything* - object
            object o = true;

            // var (compiler type inference, infers type upon declaration then locks that type to that variable - NO DYNAMIC TYPING
            // use var when the type is clear to the person reading the code
            // don't use it when it obscures useful context
            var xyz = "Hello!";
            var b1 = true;
            // var xyz = false; <- this will cause an error, no dynamic typing

            // control structures
            // loops
            for (var i = 0; i < 10; i++)
            // CSharp standard - loop brackets are on their own line 
            {
                Console.WriteLine(i);
            }

            while (false)
            {

            }

            do
            {

            }
            while (false);

            if (true)
            {

            }
            else if (false)
            {

            }
            else
            {

            }

            // List is a class defined in another namespace and needs another "Using" statement at the top of the file (for the namespace (collection?))
            List<string> list = new List<string>();
            list.Add("asdf");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // CSharp FACTS
            // > is an object-oriented programming language
            //   >> Object: a collections of properties and behavior, associate data and related behavior to represent entities, clreated from templates called Classes which define a contract for those objects at runtime.
            // > part of the .NET ecosystem/platform (framework?)
            // > strongly/statically typed (variables CANNOT change their types)
            // > unified type system
            //   >> "primitives" (types with value semantics instead of reference semantics) also inherit from object
            // > garbage collection - "managed" language (runtime is responsible for freeing unused objects from memory; saves performance time, fewer bugs, some performance penalty)
            // > functions aren't quite "first class", but in pratice, more-or-less function the same
            // > is somewhat functional, especially in practice with LINQ (LINQ is CSharp specific)
            // > asynchronous programming support with TPL (Task Processing Library)
            // > parallel programming support

            // Excpetion handling
            

        }
    }
}
