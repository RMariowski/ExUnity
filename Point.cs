using System;

namespace ExUnity
{
    [Serializable]
    public struct Point
    {
        #region Fields

        public int X;
        public int Y;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Offset

        /// <summary>
        /// Adds values to point.
        /// </summary>
        /// <param name="offsetX">X</param>
        /// <param name="offsetY">Y</param>
        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        #endregion

        #region Equals

        /// <summary>
        /// Checks if points are the same.
        /// </summary>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <returns>true if points are the same</returns>
        public static bool Equals(Point point1, Point point2)
        {
            return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
        }

        #endregion

        #region Equals

        /// <summary>
        /// Checks if point is equal to object.
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true if point is equal to object</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;
            return Equals(this, (Point) obj);
        }

        #endregion

        #region Equals

        /// <summary>
        /// Checks if points are the same.
        /// </summary>
        /// <param name="point">other point</param>
        /// <returns>true if points are the same</returns>
        public bool Equals(Point point)
        {
            return Equals(this, point);
        }

        #endregion

        #region Get Hash Code

        /// <summary>
        /// Returns hash code of point.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        #endregion

        #region Operator ==

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <returns></returns>
        public static bool operator ==(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        #endregion

        #region Operator !=

        /// <summary>
        /// != operator
        /// </summary>
        /// <param name="point1">first point</param>
        /// <param name="point2">second pint</param>
        /// <returns></returns>
        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        #endregion
    }
}