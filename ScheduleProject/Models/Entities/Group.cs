using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleProject.Models.Entities
{
    public class Group
    {
        public Group()
        {
            Schedule = new HashSet<Schedule>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        [StringLength(20)]
        [Required]
        [Index("GroupIdAndGroupName", IsUnique = true)]
        public string GroupName { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}