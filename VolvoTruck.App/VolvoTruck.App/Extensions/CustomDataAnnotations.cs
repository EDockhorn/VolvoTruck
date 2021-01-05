using System;
using System.ComponentModel.DataAnnotations;

namespace VolvoTruck.App.Extensions
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (int)value;
            if (dt >= DateTime.Now.Year)
            {
                return true;
            }
            return false;
        }
    }
}
