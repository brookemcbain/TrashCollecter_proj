using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TrashCollecter.Models
{
    public class Customer
    {


        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string RequestedDayEachWeek { get; set; }
       
        
        [DataType(DataType.Date)]
        public DateTime RequestOneTimePickUpDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartSuspensionDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime StopSuspensionDate { get; set; }

        public int AmountOwed { get; set; }
       

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
  
}
