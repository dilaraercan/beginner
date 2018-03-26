using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]//to make it "not null"
        [StringLength(255)]//nvarchar(255) 
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }//binded two classes to use them together

        [Display (Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }//foreign key

        [Display (Name = "Date of Birth")]//I want to display bDay as "Date of Birth"
        public DateTime? bDay { get; set; }//without get set its not implemented in db
    }
}
