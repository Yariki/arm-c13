namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Student : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "DateLeft", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "DateLeft", c => c.DateTime(nullable: false));
        }
    }
}
