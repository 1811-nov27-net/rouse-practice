using System;
using Animals.Library;

namespace Animals.UI
{
    class Program
    {
        // Entry point needs a static void Main(string[] args) method, that is where the execution starts
        // 'Program.cs' and program class name are just conventions

        // Naming conventions in C#:
        //      PascalCase (aka TitleCase)
        //          Classes
        //          Methods
        //          Properties
        //          Namespaces
        //      camelCase (first letter lowercase)
        //          Local variables
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Bark();

            Console.WriteLine("Hello World!");
        }
    }
}
