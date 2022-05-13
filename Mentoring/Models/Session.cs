using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Models
{
    public class Session
    {
        public long sessionId { get; set; }
        public string task { get; set; }
        public DateTime date { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
        public long groupId { get; set; }

    }
}
