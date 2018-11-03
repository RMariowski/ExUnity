using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExUnity.Localization
{
    public abstract class Language : IDisposable
    {
        #region Indexer

        public string this[string key]
        {
            get { return GetLocalizedValue(key); }
            set { SetItem(key, value); }
        }

        #endregion

        #region Fields

        private readonly Dictionary<string, string> _items = new Dictionary<string, string>();

        #endregion

        #region Properties

        public SystemLanguage Id { get; protected set; }

        public bool IsInitialized { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
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

        #region Add Localized Value

        /// <summary>
        /// Adds localized value with specified key. If key already exists, then value is override.
        /// </summary>
        /// <param name="key">key of localized value</param>
        /// <param name="value">localized value</param>
        public void AddLocalizedValue(string key, string value) 
            => _items[key] = value;

        #endregion

        #region Get Localized Value

        /// <summary>
        /// Gets localized value.
        /// </summary>
        /// <param name="key">key of localized value</param>
        /// <returns>Localized value if key exists. Otherwise it returns "[[KEY]]".</returns>
        public string GetLocalizedValue(string key)
        {
            if (!IsInitialized)
                throw new Exception("Language not initialized.");
            return _items.ContainsKey(key) ? _items[key] : "[[" + key + "]]";
        }

        #endregion

        #region Set Localized Value

        /// <summary>
        /// Sets localized value with specified key. If key doesn't exists, adds localized value.
        /// </summary>
        /// <param name="key">key of localized value</param>
        /// <param name="value">localized value</param>
        public void SetItem(string key, string value) 
            => _items[key] = value;

        #endregion

        #region Dispose

        /// <inheritdoc />
        /// <summary>
        /// Disposes language by clearing items and setting IsInitialized to false.
        /// NOTE: Invoking this method is optional.
        /// </summary>
        public void Dispose()
        {
            _items.Clear();
            IsInitialized = false;
        }

        #endregion
    }
}