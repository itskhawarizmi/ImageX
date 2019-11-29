using Extensions.DataModels;
using System;
using System.Globalization;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToStringDateISO(this DateTime datetime, bool isFormatFile = false) =>
            datetime.ToString(isFormatFile ? DateTimeFormat.FileDateTime.ToDateTimeFormatter() : 
                                             DateTimeFormat.SimpleDateTime.ToDateTimeFormatter(), 
            CultureInfo.InvariantCulture);
        
        public static bool IsISODate(this string dateString, out DateTime date) =>
            DateTime.TryParseExact(dateString, DateTimeFormat.SimpleDateTime.ToDateTimeFormatter(), CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }
}
