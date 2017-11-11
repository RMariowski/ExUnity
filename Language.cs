using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public abstract class Language
    {
        #region Indexer

        public string this[string key]
        {
            get { return GetItem(key); }
            set { SetItem(key, value); }
        }

        #endregion

        #region Fields

        protected readonly IDictionary<string, string> Items = new Dictionary<string, string>();

        #endregion

        #region Properties

        public SystemLanguage Id { get; protected set; }

        public bool IsInitialized { get; protected set; }

        #endregion

        #region Constructor

        protected Language()
        {
            Id = SystemLanguage.Unknown;
            IsInitialized = false;
        }

        #endregion

        #region Initialize

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public abstract bool Initialize();

        #endregion

        #region Add Item

        /// <summary>
        /// Adds item with specified key. If key already exists, overrides item.
        /// </summary>
        /// <param name="key">Key of the item</param>
        /// <param name="item">Item</param>
        public void AddItem(string key, string item)
        {
            Items[key] = item;
        }

        #endregion

        #region Get Item

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemKey"></param>
        /// <returns></returns>
        public string GetItem(string itemKey)
        {
            return !IsInitialized ? string.Empty : Items[itemKey];
        }

        #endregion

        #region Set Item

        /// <summary>
        /// Sets item with specified key. If key doesn't exists, adds item.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void SetItem(string key, string item)
        {
            Items[key] = item;
        }

        #endregion
    }
}