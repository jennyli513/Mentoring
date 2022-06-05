using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Mentee
    {
        
        public long menteeId { get; set; }


        [Display(Name ="First Name")]
        [Required]
        public string firstName { get; set; }


        [Display(Name = "Last Name ")]
        [Required]
        public string lastName { get; set; }


        [Display(Name = "Student ID ")]
        [Required]
        public string studentNumber { get; set; }


        [Display(Name = "Email ")]
        [Required]
        [DataType(DataType.EmailAddress)]

        public string email { get; set; }
        public string request { get; set; }

        [Display(Name ="Subject ID")]
        public long subjectId { get; set; }
    }
}
