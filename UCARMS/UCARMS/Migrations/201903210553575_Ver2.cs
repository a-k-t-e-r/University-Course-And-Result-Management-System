namespace UCARMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeLetters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradeLetterName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentRegistrationNum = c.String(nullable: false, maxLength: 8000, unicode: false),
                        StudentName = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        GradeLetterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.GradeLetters", t => t.GradeLetterId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.GradeLetterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentResults", "GradeLetterId", "dbo.GradeLetters");
            DropForeignKey("dbo.StudentResults", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentResults", new[] { "GradeLetterId" });
            DropIndex("dbo.StudentResults", new[] { "CourseId" });
            DropTable("dbo.StudentResults");
            DropTable("dbo.GradeLetters");
        }
    }
}
