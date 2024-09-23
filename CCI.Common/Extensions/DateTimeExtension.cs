﻿namespace CCI.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToUnixTimeMilliseconds(this DateTime dateTime)
        {
            DateTimeOffset dto = new(dateTime.ToUniversalTime());
            return dto.ToUnixTimeMilliseconds().ToString();
        }
    }
}
