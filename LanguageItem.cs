namespace ExUnity
{
    public class LanguageItem : Pair<string, string>
    {
        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item">Value of item</param>
        public LanguageItem(string key, string item)
            : base(key, item)
        {
        }

        #endregion
    }
}