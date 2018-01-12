using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleProject.Models.Entities
{
    public class Time
    {
        public Time()
        {
            Schedule = new HashSet<Schedule>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeID { get; set; }
        [StringLength(15)]
        public string time { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }

    }
}