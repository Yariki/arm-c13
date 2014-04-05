namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achivements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Note = c.String(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneMobile = c.String(),
                        PhoneHome = c.String(),
                        Sex = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        GroupId = c.Guid(),
                        DateFirstEnter = c.DateTime(),
                        DateLeft = c.DateTime(),
                        FacultyId = c.Guid(),
                        StudyMode = c.Int(),
                        GradeBookNumber = c.String(),
                        IsForeign = c.Boolean(),
                        SpecialityId = c.Guid(),
                        Status = c.Int(),
                        StudentId = c.Guid(),
                        StaffType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StudentId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialityId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.FacultyId)
                .Index(t => t.SpecialityId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        Region = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Apartment = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        UniversityId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        SpecialityId = c.Guid(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ParentId)
                .ForeignKey("dbo.Specialties", t => t.SpecialityId)
                .ForeignKey("dbo.People", t => t.StudentId)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.UniversityId)
                .Index(t => t.StudentId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContractId = c.Guid(nullable: false),
                        SessionId = c.Guid(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateDue = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .Index(t => t.ContractId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffId = c.Guid(nullable: false),
                        SessionId = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyId = c.Guid(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffId = c.Guid(),
                        Url = c.String(),
                        UniversityId = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StaffId)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyId = c.Guid(nullable: false),
                        StaffId = c.Guid(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StaffId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffId = c.Guid(),
                        Url = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StaffId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Note = c.String(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Student_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.SettingParameters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DefUniversity = c.Guid(nullable: false),
                        DefCoutry = c.Guid(nullable: false),
                        DefEducationLevel = c.Int(nullable: false),
                        DefInvoiceStatus = c.Int(nullable: false),
                        DefBaseStipend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DefIncreaseStipend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DefStipendMark = c.Double(nullable: false),
                        DefStipenHighMark = c.Double(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        Person_Id = c.Guid(nullable: false),
                        Address_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Address_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "SpecialityId", "dbo.Specialties");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.People");
            DropForeignKey("dbo.Marks", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Languages", "Student_Id", "dbo.People");
            DropForeignKey("dbo.Hobbies", "StudentId", "dbo.People");
            DropForeignKey("dbo.People", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Contracts", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Contracts", "StudentId", "dbo.People");
            DropForeignKey("dbo.Contracts", "SpecialityId", "dbo.Specialties");
            DropForeignKey("dbo.Specialties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Universities", "StaffId", "dbo.People");
            DropForeignKey("dbo.Faculties", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Faculties", "StaffId", "dbo.People");
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Groups", "StaffId", "dbo.People");
            DropForeignKey("dbo.Invoices", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Classes", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Classes", "StaffId", "dbo.People");
            DropForeignKey("dbo.Payments", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ParentId", "dbo.People");
            DropForeignKey("dbo.People", "StudentId", "dbo.People");
            DropForeignKey("dbo.PersonAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.PersonAddresses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Achivements", "StudentId", "dbo.People");
            DropIndex("dbo.PersonAddresses", new[] { "Address_Id" });
            DropIndex("dbo.PersonAddresses", new[] { "Person_Id" });
            DropIndex("dbo.Marks", new[] { "ClassId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.Languages", new[] { "Student_Id" });
            DropIndex("dbo.Hobbies", new[] { "StudentId" });
            DropIndex("dbo.Universities", new[] { "StaffId" });
            DropIndex("dbo.Groups", new[] { "StaffId" });
            DropIndex("dbo.Groups", new[] { "FacultyId" });
            DropIndex("dbo.Faculties", new[] { "UniversityId" });
            DropIndex("dbo.Faculties", new[] { "StaffId" });
            DropIndex("dbo.Specialties", new[] { "FacultyId" });
            DropIndex("dbo.Classes", new[] { "SessionId" });
            DropIndex("dbo.Classes", new[] { "StaffId" });
            DropIndex("dbo.Payments", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "SessionId" });
            DropIndex("dbo.Invoices", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "SpecialityId" });
            DropIndex("dbo.Contracts", new[] { "StudentId" });
            DropIndex("dbo.Contracts", new[] { "UniversityId" });
            DropIndex("dbo.Contracts", new[] { "ParentId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropIndex("dbo.People", new[] { "StudentId" });
            DropIndex("dbo.People", new[] { "SpecialityId" });
            DropIndex("dbo.People", new[] { "FacultyId" });
            DropIndex("dbo.People", new[] { "GroupId" });
            DropIndex("dbo.Achivements", new[] { "StudentId" });
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.SettingParameters");
            DropTable("dbo.Marks");
            DropTable("dbo.Languages");
            DropTable("dbo.Hobbies");
            DropTable("dbo.Universities");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
            DropTable("dbo.Specialties");
            DropTable("dbo.Classes");
            DropTable("dbo.Sessions");
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.Contracts");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
            DropTable("dbo.People");
            DropTable("dbo.Achivements");
        }
    }
}
