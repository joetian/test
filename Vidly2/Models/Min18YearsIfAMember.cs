using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // validationContext is object as customer
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

           // if ((customer.MembershipTypeId ==0) || (customer.MembershipTypeId==1))
            if ((customer.MembershipTypeId == MembershipType.Unknown) || (customer.MembershipTypeId == MembershipType.PayAsYouGo))
            {
                return ValidationResult.Success;
            }

            if (customer.Birthday ==null)
            {
                return new ValidationResult("Birthday is requried for non-Pay to go member");
            }

            var age = DateTime.Now.Year - customer.Birthday.Value.Year;

            if (age >=18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer must 18 years old to be a member");
            }
            
        }
    }
}