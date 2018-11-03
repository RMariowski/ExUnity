using UnityEngine;
using UnityEngine.UI;

namespace ExUnity.Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        #region Fields

        public string Key;

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
        /// Updates text to localized value.
        /// </summary>
        public void UpdateLocalization()
            => GetComponent<Text>().text = LanguageManager.Instance.GetLocalizedValue(Key);

        #endregion
    }
}