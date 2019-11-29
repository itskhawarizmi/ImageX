using Extensions.DataModels;
using System;

namespace Extensions
{
    public static class DateTimeFormatter
    {
        public static string ToDateTimeFormatter(this DateTimeFormat dateTimeFormat)
        {
            switch (dateTimeFormat)
            {
                case DateTimeFormat.SimpleDateTime:
                    return "yyyy-MM-ddTHH:mm:ss";

                case DateTimeFormat.ShortDateTime:
                    return "yyyy-MM-dd";

                case DateTimeFormat.LongDateTime:
                    return "yyyy-MM-ddTHH:mm:ss.fff";

                case DateTimeFormat.FileDateTime:
                    return "yyyy-MM-ddTHH-mm-ss.fff";

                default:
                    return DateTime.Now.ToString();
            }
        }
    }
}
