using System;

namespace Animals.Library
{
    public class Dog
    {
        // Properties (NOT fields)
        // Auto-property
        public string Name {get; set; }

        // Auto-property
        public string Breed {get; set; }
    
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

        // snippets: prop, propfull
    }
}
