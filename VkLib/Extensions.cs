using System;
using Newtonsoft.Json.Linq;

namespace VkLib
{
    public static class LongExtensions
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime ToDateTimeFromUnixTime(this Int64 unixTime)
        {
            return _unixEpoch.AddSeconds(unixTime);
        }
    }

    public static class DateTimeExtensions
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static Int64 ToUnixTime(this DateTime dt)
        {
            return (Int64)(dt.ToUniversalTime() - _unixEpoch).TotalSeconds;
        }
    }

    public static class JTokenExtensions
    {
        public static T SafeGetValue<T>(this JToken token, String key)
        {
            if (token[key] == null)
            {
                return default(T);
            }

            return token[key].Value<T>();
        }
    }
}