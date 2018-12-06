using System;
using System.Collections.Generic;

namespace MemoryList.Library
{
    public class MemoryList<T> : List<T>
    { 
        protected List<T> _memory = new List<T>();

        
        public new void Add(T item)
        {
            base.Add(item);
            _memory.Add(item);
        }

        public List<T> Memory()
        {
            return _memory;
        }

        public T AccessMemory(int n)
        {
            return _memory[n];
        }
        

    }
}
