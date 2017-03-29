using UnityEngine;

public static class ExtensionsUnity
{
    #region Floor To Point

    /// <summary>
    /// Converts Vector2 to floored Point
    /// </summary>
    /// <param name="vector">vector to convert</param>
    /// <returns>floored point</returns>
    public static Point FloorToPoint(this Vector2 vector)
    {
        return new Point(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
    }

    #endregion

    #region Round To Point

    /// <summary>
    /// Converts Vector2 to rounded Point
    /// </summary>
    /// <param name="vector">vector to convert</param>
    /// <returns>rounded point</returns>
    public static Point RoundToPoint(this Vector2 vector)
    {
        return new Point(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
    }

    #endregion

    #region Ceil To Point

    /// <summary>
    /// Converts Vector2 to ceiled Point
    /// </summary>
    /// <param name="vector">vector to convert</param>
    /// <returns>ceiled point</returns>
    public static Point CeilToPoint(this Vector2 vector)
    {
        return new Point(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y));
    }

    #endregion

    #region To Vector

    /// <summary>
    /// Converts Point to Vector2
    /// </summary>
    /// <param name="point">point to convert</param>
    /// <returns>Vector2 if successful</returns>
    public static Vector2 ToVector(this Point point)
    {
        return new Vector2(point.x, point.y);
    }

    #endregion
}
