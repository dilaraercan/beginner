using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validation logic

            Customer customer = new Customer();
            if (validationContext.ObjectType == typeof(Customer))
                customer = (Customer)validationContext.ObjectInstance;
            else
                customer = Mapper.Map((CustomerDto)validationContext.ObjectInstance, customer);

            //var customer = (Customer)validationContext.ObjectInstance; //connected to the customer by casting

            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)//if the user chooses the pay as you go or doesnt choose anything
                return ValidationResult.Success;
            if (customer.bDay == null)
                return new ValidationResult("Birthday is required.");
            var age = DateTime.Today.Year - customer.bDay.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("The customer should be at least 18");
        }
    }
}