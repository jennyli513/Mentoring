using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Session
    {
        [Display(Name = "Session Id")]
        public long sessionId { get; set; }
        [Display(Name = "Task")]
        public string task { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name = "Start")]
        public string startTime { get; set; }
        [Display(Name = "End")]
        public string endTime { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }
        [Display(Name = "Group Id")]
        public long groupId { get; set; }

    }
}
