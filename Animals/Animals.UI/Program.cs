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

            // using field and properties
            // using getters and setters with private field; no reason to do this - use a property
            dog.SetWeight(6);
            Console.WriteLine(dog.GetWeight());

            dog.Name = "Fido";
            System.Console.WriteLine(dog.Name);

            dog.Breed = "Golden Retreiever";

            dog.GoTo("the Park");

            Console.WriteLine("Hello World!");

            // -------------------------
            
            IAnimal animal = new Dog();
            animal = new Eagle();
            // This is okay because both classes are within/under the IAnimal type.
            // HOWEVER, you're not allowd to do dog-specific or eagle-specific things via this variable

            Eagle e = (Eagle) animal;
            // You can cast objects to more specific types, but will fail at runtime if the object is not actuall within/under that type

            // Following term sets are interchangable (mostly):
            //  > superclass, base class, parent class
            //  > subclass, derived class, child class

            // Good design (separation of concerns), means you shouldn't write code needlessly tied to one specific implementation

            // Then you can use the same code with multiple implementations of the same classes you're using
            DisplayData(new Dog());
            DisplayData(new Eagle());
        }

        public static void DisplayData(IAnimal animal)
        {
            System.Console.WriteLine(animal.Name);
        }
    }
}
