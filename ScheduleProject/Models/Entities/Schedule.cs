using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleProject.Models.Entities
{
    public class Schedule
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int DayId { get; set; }
        public int TimeId { get; set; }
        public int? SubjectId { get; set; }
        
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [ForeignKey("DayId")]
        public virtual DaysOfWeek DaysOfWeek { get; set; }

        [ForeignKey("TimeId")]
        public virtual Time Time { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}