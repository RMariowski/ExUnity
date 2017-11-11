using System.Collections.Generic;
using UnityEngine;

namespace ExUnity
{
    public class LanguageManager : Singleton<LanguageManager>
    {
        #region Fields

        private readonly IDictionary<SystemLanguage, Language> _languages =
            new Dictionary<SystemLanguage, Language>();

        #endregion

        #region Properties

        public SystemLanguage SystemLanguage
        {
            get { return Application.systemLanguage; }
        }

        public Language CurrentLanguage { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        private LanguageManager()
        {
        }

        #endregion

        #region Add Language

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        public void AddLanguage(Language language)
        {
            _languages[language.Id] = language;
        }

        #endregion

        #region Is Language Supported

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public bool IsLanguageSupported(Language language)
        {
            return language != null && IsLanguageSupported(language.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
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
        /// <param name="initializeNow"></param>
        /// <returns></returns>
        public bool SetCurrentLanguage(SystemLanguage languageId, bool initializeNow = true)
        {
            if (!IsLanguageSupported(languageId))
                return false;

            var language = _languages[languageId];
            if (initializeNow && !language.IsInitialized)
            {
                if (!language.Initialize())
                    return false;
            }

            CurrentLanguage = language;
            return true;
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
            return CurrentLanguage == null ? string.Empty : CurrentLanguage[itemKey];
        }

        #endregion
    }
}