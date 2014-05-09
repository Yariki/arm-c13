namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudyType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "StydyType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "StydyType");
        }
    }
}
