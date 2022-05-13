using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Mentee
    {
        public long menteeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string studentNumber { get; set; }
        public string email { get; set; }
        public long subjectId { get; set; }
        public string request { get; set; }
    }
}
