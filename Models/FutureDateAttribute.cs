using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DojoMUC.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt;
            
            if(value is DateTime)
                dt = (DateTime)value;
            else
                return new ValidationResult("Invalid Date/Time");
            
            if(dt < DateTime.Now)
                return new ValidationResult("Date must be in the future.");

            return ValidationResult.Success;
        }
    }
}