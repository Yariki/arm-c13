namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassAddFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "Summary", c => c.Int(nullable: false));
            AddColumn("dbo.Class", "CourseWorkPresent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Class", "CourseWorkPresent");
            DropColumn("dbo.Class", "Summary");
        }
    }
}
