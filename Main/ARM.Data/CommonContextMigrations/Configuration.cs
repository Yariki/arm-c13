using System.Data.Entity.Core.Metadata.Edm;
using ARM.Data.Models;

namespace ARM.Data.CommonContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ARM.Data.Layer.CommonContext>
    {

        private const string GuidDefault = "00000000-0000-0000-0000-000000000001";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"CommonContextMigrations";
        }

        protected override void Seed(ARM.Data.Layer.CommonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Universities.AddOrUpdate(u => u.Id, new University() { Id = Guid.Parse(GuidDefault), Name = "KPI", DateModified = DateTime.Now });
            context.Countries.AddOrUpdate(c => c.Id, new Country()
            {
                Id = Guid.Parse(GuidDefault),
                Name = "Україна",
                DateModified = DateTime.Now
            });
            context.SettingParameterses.AddOrUpdate(s => s.Id, new SettingParameters()
            {
                Id = Guid.Parse(GuidDefault),
                DefUniversity = Guid.Parse(GuidDefault),
                DefCountry = Guid.Parse(GuidDefault),
                DefEducationLevel = EducationLevel.Bachelour,
                DefInvoiceStatus = InvoiceStatus.New,
                DefBaseStipend = 900,
                DefIncreaseStipend = 1200,
                DefStipendMark = 3,
                DefStipenHighMark = 5,
                ContractPrefix = "КС",
                InvoicePrefix = "РФС",
                PaymentPrefix =  "ПС",
                ContractNumber = 0,
                InvoiceNumber = 0,
                PaymentNumber = 0
            });

        }
    }
}
