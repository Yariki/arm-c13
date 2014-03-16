namespace ARMConsoleTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Blogs", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "Edited", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Edited", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Edited");
            DropColumn("dbo.Posts", "Created");
            DropColumn("dbo.Posts", "Deleted");
            DropColumn("dbo.Blogs", "Edited");
            DropColumn("dbo.Blogs", "Created");
            DropColumn("dbo.Blogs", "Deleted");
        }
    }
}
