namespace ARMManyTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.PersonAddress",
                c => new
                    {
                        AddressID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AddressID, t.PersonID })
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.AddressID)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonAddress", "PersonID", "dbo.People");
            DropForeignKey("dbo.PersonAddress", "AddressID", "dbo.Addresses");
            DropIndex("dbo.PersonAddress", new[] { "PersonID" });
            DropIndex("dbo.PersonAddress", new[] { "AddressID" });
            DropTable("dbo.PersonAddress");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
