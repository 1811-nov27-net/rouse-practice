namespace Animals.Library
{
    public abstract class ABird : IAnimal
    {
        // Abstract classes cannot be instantiated, but can provide implementation to be shared by subclasses.

        public abstract string Name { get; set; }

        public void GoTo(string location)
        {
            System.Console.WriteLine($"Flying to {location}.");
        }

        public abstract void MakeSound();
    }
}