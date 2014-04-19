namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Settings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SettingParameters", "DefCountry", c => c.Guid(nullable: false));
            DropColumn("dbo.SettingParameters", "DefCoutry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SettingParameters", "DefCoutry", c => c.Guid(nullable: false));
            DropColumn("dbo.SettingParameters", "DefCountry");
        }
    }
}
