using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleProject.Models
{
    public class ScheduleModel
    {
        public int DayId { get; set; }
        public int TimeId { get; set; }
        public int GroupId { get; set; }
        public int? SubjectId { get; set; }
    }
}