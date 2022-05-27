using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Subject
    {
        [Display(Name = "Subject Id")]
        public long subjectId { get; set; }
        [Display(Name = "Code")]
        public string subjectCode { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}
