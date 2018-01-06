using System;

namespace ExUnity
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets unix timestamp in seconds based on date time.
        /// </summary>
        public static int ToUnixTimestamp(this DateTime dateTime) 
            => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}