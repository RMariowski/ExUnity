using UnityEngine;

namespace ExUnity
{
    public static class Helpers
    {
        #region Blank Image

        /// <summary>
        /// Creates image filled with one color.
        /// </summary>
        /// <param name="width">width of image</param>
        /// <param name="height">height of image</param>
        /// <param name="color">color of image</param>
        /// <returns>image as Texture2D if successful</returns>
        public static Texture2D CreateBlankImage(int width, int height, Color color)
        {
            var result = new Texture2D(width, height);
            var colors = new Color[4];
            for (var i = 0; i < 4; i++)
                colors[i] = color;
            result.SetPixels(colors);
            result.Apply();
            return result;
        }

        #endregion
    }
}