using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Mentor
    {
        public long mentorId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int studentNumber { get; set; }
        public string email { get; set; }
        public string availableDay { get; set; }
        public string availableTime { get; set; }
        public string subjectId { get; set; }
    }
}
