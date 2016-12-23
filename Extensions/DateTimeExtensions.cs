using System;

namespace IainPlimmerApi.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FormatMe(this DateTime dt)
        {
            return dt.ToString("dd MMMM yyyy");
        }
    }   
}