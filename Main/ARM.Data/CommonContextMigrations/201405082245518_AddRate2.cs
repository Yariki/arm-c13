namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RateMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RateMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mark = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Rate");
        }
    }
}