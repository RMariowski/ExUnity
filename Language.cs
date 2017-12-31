using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public abstract class Language : IDisposable
    {
        #region Indexer

        public string this[string key]
        {
            get { return GetItem(key); }
            set { SetItem(key, value); }
        }

        #endregion

        #region Fields

        protected readonly Dictionary<string, string> Items = new Dictionary<string, string>();

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
        /// Initializes language.
        /// NOTE: When you override it, don't forget to set IsInitialized to true, when everything goes well.
        /// </summary>
        /// <returns>True if initialization was successful, false otherwise.</returns>
        public abstract bool Initialize();

        #endregion

        #region Add Item

        /// <summary>
        /// Adds item with specified key. If key already exists, overrides item.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item">Value of language item</param>
        public void AddItem(string key, string item)
        {
            Items[key] = item;
        }

        /// <summary>
        /// Adds language item. If language item already exists, overrides it.
        /// </summary>
        /// <param name="languageItem">Language item to add.</param>
        public void AddItem(LanguageItem languageItem)
        {
            AddItem(languageItem.First, languageItem.Second);
        }

        #endregion

        #region Get Item

        /// <summary>
        /// Gets item of language.
        /// </summary>
        /// <param name="itemKey">Item's key to get</param>
        /// <returns>Value of language item if key exists. Otherwise it returns "[[KEY]]".</returns>
        public string GetItem(string itemKey)
        {
            if (!IsInitialized)
                throw new Exception("Language not initialized.");
            return Items.ContainsKey(itemKey) ? Items[itemKey] : "[[" + itemKey + "]]";
        }

        #endregion

        #region Set Item

        /// <summary>
        /// Sets language item with specified key. If key doesn't exists, adds item.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item">Value of language item</param>
        public void SetItem(string key, string item)
        {
            Items[key] = item;
        }

        /// <summary>
        /// Sets language item.
        /// </summary>
        /// <param name="languageItem">Language item to set</param>
        public void SetItem(LanguageItem languageItem)
        {
            SetItem(languageItem.First, languageItem.Second);
        }

        #endregion

        #region Dispose

        /// <inheritdoc />
        /// <summary>
        /// Disposes language by clearing items and setting IsInitialized to false.
        /// NOTE: Invoking this method is optional.
        /// </summary>
        public void Dispose()
        {
            Items.Clear();
            IsInitialized = false;
        }

        #endregion
    }
}