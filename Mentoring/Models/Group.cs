using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Group
    {
        [Display(Name = "Group Id")]
        public long groupId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }
        [Display(Name = "Mentor Id")]
        public long mentorId { get; set; }
        [Display(Name = "Mentee Id")]
        public long menteeId { get; set; }
        [Display(Name = "Subject Id")]
        public long subjectId { get; set; }
        [Display(Name = "Semester Id")]
        public long semesterId { get; set; }

    }
}
