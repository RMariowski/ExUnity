using UnityEngine;

namespace ExUnity
{
    public class PlayerPrefsEx
    {
        #region Set Bool

        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        #endregion

        #region Get Bool

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        /// <param name="key"></param>
        public static bool GetBool(string key)
        {
            return PlayerPrefs.GetInt(key) == 1;
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        public static bool GetBool(string key, bool defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        #endregion

        #region Set Long

        /// <summary>
        /// Sets the value of the preference identified by key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetLong(string key, long value)
        {
            int lowBits;
            int highBits;
            SplitLong(value, out lowBits, out highBits);

            PlayerPrefs.SetInt(key + "_LowBits", lowBits);
            PlayerPrefs.SetInt(key + "_HighBits", highBits);
        }

        #endregion

        #region Get Long

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        /// <param name="key"></param>
        public static long GetLong(string key)
        {
            int lowBits = PlayerPrefs.GetInt(key + "_LowBits");
            int highBits = PlayerPrefs.GetInt(key + "_HighBits");

            // Unsigned, to prevent loss of sign bit.
            ulong ret = (uint) highBits;
            ret = ret << 32;
            return (long) (ret | (uint) lowBits);
        }

        /// <summary>
        /// Returns the value corresponding to key in the preference file if it exists.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        public static long GetLong(string key, long defaultValue)
        {
            int lowBits;
            int highBits;

            SplitLong(defaultValue, out lowBits, out highBits);
            lowBits = PlayerPrefs.GetInt(key + "_LowBits", lowBits);
            highBits = PlayerPrefs.GetInt(key + "_HighBits", highBits);

            // Unsigned, to prevent loss of sign bit.
            ulong ret = (uint) highBits;
            ret = ret << 32;
            return (long) (ret | (uint) lowBits);
        }

        #endregion

        #region Split Long

        /// <summary>
        /// Splits long to 2 integers.
        /// </summary>
        /// <param name="input">Long to split</param>
        /// <param name="lowBits">First integer</param>
        /// <param name="highBits">Second integer</param>
        private static void SplitLong(long input, out int lowBits, out int highBits)
        {
            // Unsigned everything, to prevent loss of sign bit.
            lowBits = (int) (uint) (ulong) input;
            highBits = (int) (uint) (input >> 32);
        }

        #endregion
    }
}