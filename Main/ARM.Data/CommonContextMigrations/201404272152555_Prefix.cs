namespace ARM.Data.CommonContextMigrations
{
    using System.Data.Entity.Migrations;

    public partial class Prefix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SettingParameters", "ContractPrefix", c => c.String());
            AddColumn("dbo.SettingParameters", "InvoicePrefix", c => c.String());
            AddColumn("dbo.SettingParameters", "PaymentPrefix", c => c.String());
            AddColumn("dbo.SettingParameters", "ContractNumber", c => c.Long(nullable: false));
            AddColumn("dbo.SettingParameters", "InvoiceNumber", c => c.Long(nullable: false));
            AddColumn("dbo.SettingParameters", "PaymentNumber", c => c.Long(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.SettingParameters", "PaymentNumber");
            DropColumn("dbo.SettingParameters", "InvoiceNumber");
            DropColumn("dbo.SettingParameters", "ContractNumber");
            DropColumn("dbo.SettingParameters", "PaymentPrefix");
            DropColumn("dbo.SettingParameters", "InvoicePrefix");
            DropColumn("dbo.SettingParameters", "ContractPrefix");
        }
    }
}