using System;

namespace IainPlimmerApi.Extensions
{
    public static class MyExtensions
    {
        public static DateTime ToDate(this String str)
        {
            return Convert.ToDateTime(str);
        }
    }   
}