using System;
using UnityEngine;

public static class Helpers
{
    #region Clamp

    /// <summary>
    /// Clamps value.
    /// </summary>
    /// <typeparam name="T">implements IComparable</typeparam>
    /// <param name="value">specified value</param>
    /// <param name="min">minimum value</param>
    /// <param name="max">maximum value</param>
    /// <returns>clamped value</returns>
    public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
    {
        if (value.CompareTo(max) > 0)
            return max;
        return value.CompareTo(min) < 0 ? min : value;
    }

    #endregion

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