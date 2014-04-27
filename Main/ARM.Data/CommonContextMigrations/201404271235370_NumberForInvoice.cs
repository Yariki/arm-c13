namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberForInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoice", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoice", "Number");
        }
    }
}
