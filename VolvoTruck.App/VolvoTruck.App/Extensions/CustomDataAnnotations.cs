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
            if ((int)value >= DateTime.Now.Year) return true;

            return false;
        }
    }
}
