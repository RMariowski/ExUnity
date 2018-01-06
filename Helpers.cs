using UnityEngine;

namespace ExUnity
{
    public static class Helpers
    {
        #region Blank Texture

        /// <summary>
        /// Creates texture filled with one color.
        /// </summary>
        /// <param name="width">width of texture</param>
        /// <param name="height">height of texture</param>
        /// <param name="color">color of texture</param>
        public static Texture2D CreateBlankTexture(int width, int height, Color color)
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