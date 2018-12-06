using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTesting.Library
{
    //  C# supports adding methods to classes that are already defined, even the framework's classes like List or string
    public static class MyCollectionExtensions
    {
        public static bool Empty(this MyCollection coll)
        {
            return coll.Length == 0;
            // Equivalent to "if length is 0, return true, else false", but better to 
        }
    }
}
