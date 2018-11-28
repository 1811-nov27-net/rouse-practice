using System;

namespace Animals.Library
{
    public class Dog : IAnimal
    {
        // Properties (NOT fields)
        // Only auto-properties have implicit backing fields, as soon as you give a body to the get or set, you need to add a private field yourself.
       
       // Weird example to show you din't even need a field
        public string Name 
        {
            get { return "Bob"; } 
            set { System.Console.WriteLine("inside property setter"); }
        }

        // Property with validation
        private string _breed;
        public string Breed 
        { 
            get { return _breed; } 
            set
            {
                // validation - no null or empty allowed
                if (value != null && value != "")
                {
                    _breed = value;
                }
            }
        }
    
        // Property (with explicit backing field)
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                // Uses keyword 'value' in a setter
                _age = value;
            }
        }
        private int Weight;

        // Classic getters and setters
        public int GetWeight()
        {
            return Weight;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        public void Bark()
        {
            Console.WriteLine("Woof");
        }

        public void MakeSound()
        {
            Bark();
        }

        public void GoTo(string location)
        {
            // String interpolation syntax; prefix with $, inside braces reads as code (run through .ToString())
            string output = $"Walking to {location}.";
            System.Console.WriteLine(output);
        }

        // snippets: prop, propfull
    }
}
