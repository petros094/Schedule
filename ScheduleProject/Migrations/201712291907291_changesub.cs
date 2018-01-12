namespace ScheduleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesub : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Schedules", new[] { "SubjectId" });
            AlterColumn("dbo.Schedules", "SubjectId", c => c.Int());
            CreateIndex("dbo.Schedules", "SubjectId");
            AddForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects", "SubjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Schedules", new[] { "SubjectId" });
            AlterColumn("dbo.Schedules", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "SubjectId");
            AddForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}
