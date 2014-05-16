namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class NumberForPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payment", "Number", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Payment", "Number");
        }
    }
}