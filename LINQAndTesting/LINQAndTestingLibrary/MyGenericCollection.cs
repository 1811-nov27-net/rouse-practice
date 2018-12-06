using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTestingLibrary
{
    // In C#, there's 'regular parameters' (maybe an Add method can accept 2 and 2, 5 and 3, 1 and 0, it can accept many values
    // There's also  'type parameters' (or 'generics'), which means a class or method can work with different type without being a whole new class/method
    // The way we do type parameters is with angle brackets - <type>; some, like Dictionary, can take 

    // Make class generic with angle brackets in its defintion
    // -  This defines a type parameter in that class.  By convention, call it "T" (stands for type) if there's only one

    // Generic/type parameter constraints:
    // -  You can require that it is derived from some type
    //   -  MyGenericCollection<T> where T : SomeType
    // -  You can require that it be a struct
    //   -  MyGenericCollection<T> where T : struct
    // -  You can require that it have a default constructor
    //   -  MyGenericCollection<T> where T : new()
    // -  You can have multiple constraints
    public class MyGenericCollection<T>
    {
        private List<T> _list = new List<T>();
        // We don't know what T is, it could be anything.  So this member will have a different type for every instance of MyGenericCollection

        public void AddDefaultValue()
        {
            // Not allowed unless we put "new()" constraint where T is declared
            _list.Add(new T());
        }

        public virtual void Add(T item)
        {
            _list.Add(item);
        }
    }
}
