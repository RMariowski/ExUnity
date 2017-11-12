using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public class LanguageManager : Singleton<LanguageManager>
    {
        #region Fields

        private readonly Dictionary<SystemLanguage, Language> _languages = new Dictionary<SystemLanguage, Language>();

        #endregion

        #region Properties

        public static SystemLanguage SystemLanguage
        {
            get { return Application.systemLanguage; }
        }

        public SystemLanguage DefaultLanguage { get; set; }

        public Language CurrentLanguage { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        private LanguageManager()
        {
            DefaultLanguage = SystemLanguage.Unknown;
        }

        #endregion

        #region Add Language

        /// <summary>
        /// Adds language to list of supported languages.
        /// </summary>
        /// <param name="language">Language to add</param>
        public void AddLanguage(Language language)
        {
            if (language.Id == SystemLanguage.Unknown)
                throw new Exception("Invalid language id");

            _languages[language.Id] = language;
        }

        /// <summary>
        /// Creates and adds language to list of supported languages.
        /// </summary>
        public void AddLanguage<T>() where T : Language, new()
        {
            AddLanguage(new T());
        }

        #endregion

        #region Is Language Supported

        /// <summary>
        /// Checks whatever language is supported.
        /// </summary>
        /// <param name="languageId">ID of language to check</param>
        /// <returns>True if language is supported, false otherwise.</returns>
        private bool IsLanguageSupported(SystemLanguage languageId)
        {
            return _languages.ContainsKey(languageId);
        }

        #endregion

        #region Set Current Language

        /// <summary>
        /// Sets current language to specified one.
        /// </summary>
        /// <param name="languageId">Language id to set</param>
        /// <param name="initializeNow">If true, then immediately initializes new current language</param>
        /// <param name="releaseCurrent">If true, then releases current language</param>
        /// <returns>True if new current language has been set successfully</returns>
        public bool SetCurrentLanguage(SystemLanguage languageId, bool initializeNow = true,
            bool releaseCurrent = true)
        {
            if (!IsLanguageSupported(languageId))
            {
                if (DefaultLanguage == SystemLanguage.Unknown)
                    return false;
                languageId = DefaultLanguage;
            }

            var language = _languages[languageId];
            if (initializeNow && !language.IsInitialized)
            {
                if (!language.Initialize())
                    return false;
            }

            if (CurrentLanguage != null && releaseCurrent)
                CurrentLanguage.Dispose();

            CurrentLanguage = language;
            return true;
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
            if (CurrentLanguage == null)
                throw new Exception("Current language is not set.");
            return CurrentLanguage[itemKey];
        }

        #endregion
    }
}