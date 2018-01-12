namespace ScheduleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DaysOfWeeks", "Day", c => c.String(maxLength: 15));
            AlterColumn("dbo.Groups", "GroupName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Subjects", "SubjectName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Times", "time", c => c.String(maxLength: 15));
            CreateIndex("dbo.Groups", "GroupName", unique: true, name: "GroupIdAndGroupName");
            CreateIndex("dbo.Subjects", "SubjectName", unique: true, name: "SubjectIdAndSubjectName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subjects", "SubjectIdAndSubjectName");
            DropIndex("dbo.Groups", "GroupIdAndGroupName");
            AlterColumn("dbo.Times", "time", c => c.String());
            AlterColumn("dbo.Subjects", "SubjectName", c => c.String());
            AlterColumn("dbo.Groups", "GroupName", c => c.String());
            AlterColumn("dbo.DaysOfWeeks", "Day", c => c.String());
        }
    }
}
