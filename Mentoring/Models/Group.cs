using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Group
    {
        public long groupId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string comments { get; set; }
        public long mentorId { get; set; }
        public long menteeId { get; set; }
        public long subjectId { get; set; }
        public long semesterId { get; set; }

    }
}
