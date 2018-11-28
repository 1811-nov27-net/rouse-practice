namespace Animals.Library
{
    public interface IAnimal
    {
        // An interface is a contract that a class has to follow specifying some methods it needs to have, with their argument types and return type.

        // No implementation possible in interfaces
        // No data either, no fields, just method names, arguments, and return type

        // No backing field or auto-implementation, this is just "any IAnimal class must have a Name property"
        string Name { get; set; }

        void MakeSound();

        void GoTo(string location);

        // There is no "void type" or "void class", 'void' simply means 'returns nothing'

        // Every interface memeber must have the access modifier of the whole interface (ex: "public")
    }
}