using System;

namespace ExUnity
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets unix timestamp in seconds based on date time.
        /// </summary>
        /// <returns>Unix timestamp in seconds.</returns>
        public static int ToUnixTimestamp(this DateTime dateTime)
        {
            return (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}