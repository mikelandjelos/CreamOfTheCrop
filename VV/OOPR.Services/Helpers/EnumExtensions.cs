using System;
using System.ComponentModel.DataAnnotations;

namespace OOPR.Services.Helpers
{
    public static class EnumExtensions
    {
        public static string GetEnumDisplayName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Name; 
            }

            return value.ToString();
        }
    }
}
