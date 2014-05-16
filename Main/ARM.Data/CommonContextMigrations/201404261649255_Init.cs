namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achivement",
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
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Address",
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
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);

            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
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
                .ForeignKey("dbo.Parent", t => t.ParentId)
                .ForeignKey("dbo.Specialty", t => t.SpecialityId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.University", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.UniversityId)
                .Index(t => t.StudentId)
                .Index(t => t.SpecialityId);

            CreateTable(
                "dbo.Invoice",
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
                .ForeignKey("dbo.Contract", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .Index(t => t.ContractId)
                .Index(t => t.SessionId);

            CreateTable(
                "dbo.Payment",
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
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);

            CreateTable(
                "dbo.Session",
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
                "dbo.Class",
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
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .ForeignKey("dbo.Session", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.SessionId);

            CreateTable(
                "dbo.Specialty",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyId = c.Guid(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.FacultyId);

            CreateTable(
                "dbo.Faculty",
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
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .ForeignKey("dbo.University", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.UniversityId);

            CreateTable(
                "dbo.Group",
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
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .ForeignKey("dbo.Faculty", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.StaffId);

            CreateTable(
                "dbo.University",
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
                .ForeignKey("dbo.Staff", t => t.StaffId)
                .Index(t => t.StaffId);

            CreateTable(
                "dbo.Hobby",
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
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Mark",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ClassId = c.Guid(),
                        Date = c.DateTime(),
                        Type = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId);

            CreateTable(
                "dbo.SettingParameters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DefUniversity = c.Guid(nullable: false),
                        DefCountry = c.Guid(nullable: false),
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
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Language = c.Int(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.StudentLanguages",
                c => new
                    {
                        LanguageId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LanguageId, t.StudentId })
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Parent",
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
                        StudentId = c.Guid(),
                        AddressId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AddressId);

            CreateTable(
                "dbo.Staff",
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
                        StaffType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Student",
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
                        AddressId = c.Guid(nullable: false),
                        LivingAddressId = c.Guid(nullable: false),
                        GroupId = c.Guid(),
                        DateFirstEnter = c.DateTime(nullable: false),
                        DateLeft = c.DateTime(),
                        FacultyId = c.Guid(),
                        StudyMode = c.Int(nullable: false),
                        GradeBookNumber = c.String(),
                        IsForeign = c.Boolean(nullable: false),
                        SpecialityId = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Address", t => t.LivingAddressId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .ForeignKey("dbo.Specialty", t => t.SpecialityId)
                .Index(t => t.AddressId)
                .Index(t => t.LivingAddressId)
                .Index(t => t.GroupId)
                .Index(t => t.FacultyId)
                .Index(t => t.SpecialityId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "SpecialityId", "dbo.Specialty");
            DropForeignKey("dbo.Student", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Student", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Student", "LivingAddressId", "dbo.Address");
            DropForeignKey("dbo.Student", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Parent", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Parent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Achivement", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Mark", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Mark", "ClassId", "dbo.Class");
            DropForeignKey("dbo.StudentLanguages", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentLanguages", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Hobby", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Contract", "UniversityId", "dbo.University");
            DropForeignKey("dbo.Contract", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Contract", "SpecialityId", "dbo.Specialty");
            DropForeignKey("dbo.Specialty", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.University", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Faculty", "UniversityId", "dbo.University");
            DropForeignKey("dbo.Faculty", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Group", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Group", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Invoice", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Class", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Class", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Payment", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "ContractId", "dbo.Contract");
            DropForeignKey("dbo.Contract", "ParentId", "dbo.Parent");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropIndex("dbo.Student", new[] { "SpecialityId" });
            DropIndex("dbo.Student", new[] { "FacultyId" });
            DropIndex("dbo.Student", new[] { "GroupId" });
            DropIndex("dbo.Student", new[] { "LivingAddressId" });
            DropIndex("dbo.Student", new[] { "AddressId" });
            DropIndex("dbo.Parent", new[] { "AddressId" });
            DropIndex("dbo.Parent", new[] { "StudentId" });
            DropIndex("dbo.StudentLanguages", new[] { "StudentId" });
            DropIndex("dbo.StudentLanguages", new[] { "LanguageId" });
            DropIndex("dbo.Mark", new[] { "ClassId" });
            DropIndex("dbo.Mark", new[] { "StudentId" });
            DropIndex("dbo.Hobby", new[] { "StudentId" });
            DropIndex("dbo.University", new[] { "StaffId" });
            DropIndex("dbo.Group", new[] { "StaffId" });
            DropIndex("dbo.Group", new[] { "FacultyId" });
            DropIndex("dbo.Faculty", new[] { "UniversityId" });
            DropIndex("dbo.Faculty", new[] { "StaffId" });
            DropIndex("dbo.Specialty", new[] { "FacultyId" });
            DropIndex("dbo.Class", new[] { "SessionId" });
            DropIndex("dbo.Class", new[] { "StaffId" });
            DropIndex("dbo.Payment", new[] { "InvoiceId" });
            DropIndex("dbo.Invoice", new[] { "SessionId" });
            DropIndex("dbo.Invoice", new[] { "ContractId" });
            DropIndex("dbo.Contract", new[] { "SpecialityId" });
            DropIndex("dbo.Contract", new[] { "StudentId" });
            DropIndex("dbo.Contract", new[] { "UniversityId" });
            DropIndex("dbo.Contract", new[] { "ParentId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropIndex("dbo.Achivement", new[] { "StudentId" });
            DropTable("dbo.Student");
            DropTable("dbo.Staff");
            DropTable("dbo.Parent");
            DropTable("dbo.StudentLanguages");
            DropTable("dbo.User");
            DropTable("dbo.SettingParameters");
            DropTable("dbo.Mark");
            DropTable("dbo.Language");
            DropTable("dbo.Hobby");
            DropTable("dbo.University");
            DropTable("dbo.Group");
            DropTable("dbo.Faculty");
            DropTable("dbo.Specialty");
            DropTable("dbo.Class");
            DropTable("dbo.Session");
            DropTable("dbo.Payment");
            DropTable("dbo.Invoice");
            DropTable("dbo.Contract");
            DropTable("dbo.Country");
            DropTable("dbo.Address");
            DropTable("dbo.Achivement");
        }
    }
}