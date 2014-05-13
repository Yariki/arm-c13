namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentStipend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Stipend", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Stipend");
        }
    }
}
