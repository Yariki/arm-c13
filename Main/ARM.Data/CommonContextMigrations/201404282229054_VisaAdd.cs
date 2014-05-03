namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisaAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        PlaceOfIssue = c.String(),
                        VisaType = c.Int(nullable: false),
                        PassportNumber = c.String(),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visa", "StudentId", "dbo.Student");
            DropIndex("dbo.Visa", new[] { "StudentId" });
            DropTable("dbo.Visa");
        }
    }
}
