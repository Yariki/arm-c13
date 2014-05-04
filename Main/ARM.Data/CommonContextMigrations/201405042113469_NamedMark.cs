namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamedMark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mark", "MarkRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mark", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mark", "Name");
            DropColumn("dbo.Mark", "MarkRate");
        }
    }
}
