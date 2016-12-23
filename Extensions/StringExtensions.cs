using System;

namespace IainPlimmerApi.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToDate(this String str)
        {
            return Convert.ToDateTime(str);
        }
    }   
}