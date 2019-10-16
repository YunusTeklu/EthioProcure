using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidateFile: ValidationAttribute
    {
       protected override ValidationResult IsValid(object value, 
           ValidationContext validationContext)
        {
            byte[] file = value as byte[];

            // The file is required.
            if (file == null)
            {
                return new ValidationResult("Please upload a file!");
            }
            return ValidationResult.Success;
        }
        
    }
}