namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeStudyType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "StudyType", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "StydyType");
        }

        public override void Down()
        {
            AddColumn("dbo.Student", "StydyType", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "StudyType");
        }
    }
}