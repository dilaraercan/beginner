using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]//to make it "not null", these are called data annotations
        [StringLength(255)]//nvarchar(255) 
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }//foreign key

        //[Min18YearsIfAMember]
        public DateTime? bDay { get; set; }//without get set its not implemented in db
    }
}