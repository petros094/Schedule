namespace ScheduleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaysOfWeeks",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DaysOfWeeks", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.DayId)
                .Index(t => t.TimeId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeID = c.Int(nullable: false, identity: true),
                        time = c.String(),
                    })
                .PrimaryKey(t => t.TimeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Schedules", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Schedules", "DayId", "dbo.DaysOfWeeks");
            DropIndex("dbo.Schedules", new[] { "SubjectId" });
            DropIndex("dbo.Schedules", new[] { "TimeId" });
            DropIndex("dbo.Schedules", new[] { "DayId" });
            DropIndex("dbo.Schedules", new[] { "GroupId" });
            DropTable("dbo.Times");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Schedules");
            DropTable("dbo.DaysOfWeeks");
        }
    }
}
