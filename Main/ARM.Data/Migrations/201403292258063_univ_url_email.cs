namespace ARM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class univ_url_email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Universities", "Url", c => c.String());
            AddColumn("dbo.Universities", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Universities", "Email");
            DropColumn("dbo.Universities", "Url");
        }
    }
}
