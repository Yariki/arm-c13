namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class EmployersAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Contact = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Url = c.String(),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Student", "EmployerId", c => c.Guid());
            CreateIndex("dbo.Student", "EmployerId");
            AddForeignKey("dbo.Student", "EmployerId", "dbo.Employer", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Student", "EmployerId", "dbo.Employer");
            DropIndex("dbo.Student", new[] { "EmployerId" });
            DropColumn("dbo.Student", "EmployerId");
            DropTable("dbo.Employer");
        }
    }
}