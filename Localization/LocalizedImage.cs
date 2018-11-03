using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ExUnity.Localization
{
    [Serializable]
    public class LanguageImage
    {
        public SystemLanguage Language;
        public Sprite Sprite;
    }

    [RequireComponent(typeof(Image))]
    public class LocalizedImage : MonoBehaviour
    {
        #region Fields

        public LanguageImage[] Values;

        #endregion

        #region Start

        /// <summary>
        /// Unity's Start()
        /// </summary>
        private void Start()
            => UpdateLocalization();

        #endregion

        #region Update Localization

        /// <summary>
        /// Updates image to localized value.
        /// </summary>
        public void UpdateLocalization()
        {
            var currentLanguage = LanguageManager.Instance.CurrentLanguage;
            GetComponent<Image>().sprite = Values.FirstOrDefault(v => v.Language == currentLanguage.Id)?.Sprite;
        }

        #endregion
    }
}