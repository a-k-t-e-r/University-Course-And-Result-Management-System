namespace UCARMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassAllocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ClassRoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false, storeType: "date"),
                        ToDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.ClassRoomId)
                .Index(t => t.CourseId)
                .Index(t => t.DayId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 11, unicode: false),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 11, unicode: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayName = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditRemain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 100, unicode: false),
                        CourseCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        ContactNo = c.String(nullable: false, maxLength: 100, unicode: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentEnrolls",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        StudentRegistrationNo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        StudentName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Department = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StuRegNo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        StuName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ContactNo = c.String(nullable: false, maxLength: 11, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentRegistrations", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.StudentEnrolls", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ClassAllocations", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.ClassAllocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.ClassAllocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.ClassAllocations", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.StudentRegistrations", new[] { "DepartmentId" });
            DropIndex("dbo.StudentEnrolls", new[] { "CourseId" });
            DropIndex("dbo.CourseAssigns", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssigns", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssigns", new[] { "CourseId" });
            DropIndex("dbo.ClassAllocations", new[] { "DepartmentId" });
            DropIndex("dbo.ClassAllocations", new[] { "DayId" });
            DropIndex("dbo.ClassAllocations", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.ClassAllocations", new[] { "ClassRoomId" });
            DropTable("dbo.StudentRegistrations");
            DropTable("dbo.StudentEnrolls");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseAssigns");
            DropTable("dbo.Days");
            DropTable("dbo.Semesters");
            DropTable("dbo.Department");
            DropTable("dbo.Courses");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.ClassAllocations");
        }
    }
}
