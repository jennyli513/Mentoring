using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Subject
    {
        public long subjectId { get; set; }
        public string subjectCode { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
