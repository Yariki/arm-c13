namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class MarkAddCertification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mark", "IsCertification", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Mark", "IsCertification");
        }
    }
}