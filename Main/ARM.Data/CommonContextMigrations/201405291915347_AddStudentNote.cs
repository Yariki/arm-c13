namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Note");
        }
    }
}
