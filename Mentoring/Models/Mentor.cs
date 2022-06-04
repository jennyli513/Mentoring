using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Mentor
    {
        public long mentorId { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Student Number")]
        public int studentNumber { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Available Day")]
        public string availableDay { get; set; }
        [Display(Name = "Available Time")]
        public string availableTime { get; set; }
        [Display(Name = "Subject")]
        public string subject { get; set; }

        [NotMapped]
        public List<CheckBox_Subject> subjectList { get; set; }

        [NotMapped]
        public List<CheckBox_Weekdays> weekdayList { get; set; }
    }
}
