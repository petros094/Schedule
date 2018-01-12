namespace ScheduleProject.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScheduleEntity : DbContext
    {
        public ScheduleEntity()
            : base("name=ScheduleEntity")
        {
        }

        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<DaysOfWeek> Days { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
