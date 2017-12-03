using System;
using System.Collections.Generic;

namespace ExUnity
{
    public static class Extensions
    {
        #region Static Fields

        private static readonly Random Random = new Random();

        #endregion

        #region Convert to Byte

        /// <summary>
        /// Converts string to byte
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>byte if successful</returns>
        public static byte ToByte(this string str)
        {
            return Convert.ToByte(str);
        }

        #endregion

        #region Convert to Int16

        /// <summary>
        /// Converts string to short int
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>short int if successful</returns>
        public static short ToInt16(this string str)
        {
            return Convert.ToInt16(str);
        }

        #endregion

        #region Convert to Int32

        /// <summary>
        /// Converts string to int
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>int if successful</returns>
        public static int ToInt32(this string str)
        {
            return Convert.ToInt32(str);
        }

        #endregion

        #region Convert to Int64

        /// <summary>
        /// Converts string to long
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>long if successful</returns>
        public static long ToInt64(this string str)
        {
            return Convert.ToInt64(str);
        }

        #endregion

        #region Convert to Short

        /// <summary>
        /// Converts string to short int
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>short int if successful</returns>
        public static short ToShort(this string str)
        {
            return str.ToInt16();
        }

        #endregion

        #region Convert to Int

        /// <summary>
        /// Converts string to int
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>int if successful</returns>
        public static int ToInt(this string str)
        {
            return str.ToInt32();
        }

        #endregion

        #region Convert to Long

        /// <summary>
        /// Converts string to long
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>long if successful</returns>
        public static long ToLong(this string str)
        {
            return str.ToInt64();
        }

        #endregion

        #region Convert to Single

        /// <summary>
        /// Converts string to float
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>float if successful</returns>
        public static float ToSingle(this string str)
        {
            return Convert.ToSingle(str);
        }

        #endregion

        #region Convert to Float

        /// <summary>
        /// Converts string to byte
        /// </summary>
        /// <param name="str">string to convert</param>
        /// <returns>float if successful</returns>
        public static float ToFloat(this string str)
        {
            return str.ToSingle();
        }

        #endregion

        #region Shuffle

        /// <summary>
        /// Real shuffle of List
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion
    }
}