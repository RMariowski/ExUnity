using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        #region Add

        /// <summary>
        /// Adds item to set.
        /// </summary>
        /// <param name="item">item to add</param>
        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes item from set.
        /// </summary>
        /// <param name="item">item to remove</param>
        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }

        #endregion
    }
}