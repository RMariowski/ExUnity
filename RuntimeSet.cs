using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        /// <summary>
        /// Adds item to set.
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        /// <summary>
        /// Removes item from set.
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }
    }
}