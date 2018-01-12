using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleProject.Models.Entities
{
    public class Subject
    {
        public Subject()
        {
            Schedule = new HashSet<Schedule>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        [StringLength(50)]
        [Required]
        [Index("SubjectIdAndSubjectName", IsUnique = true)]
        public string SubjectName { get; set; }


        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}