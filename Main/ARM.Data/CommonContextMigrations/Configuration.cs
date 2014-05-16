using System.Data.Entity.Migrations;
using ARM.Data.Layer;

namespace ARM.Data.CommonContextMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CommonContext>
    {
        private const string GuidDefault = "00000000-0000-0000-0000-000000000001";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"CommonContextMigrations";
        }

        protected override void Seed(CommonContext context)
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

            context.Universities.AddOrUpdate(u => u.Id,
                new University {Id = Guid.Parse(GuidDefault), Name = "KPI", DateModified = DateTime.Now});
            context.Countries.AddOrUpdate(c => c.Id, new Country
            {
                Id = Guid.Parse(GuidDefault),
                Name = "Україна",
                DateModified = DateTime.Now
            });
            context.SettingParameterses.AddOrUpdate(s => s.Id, new SettingParameters
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
                PaymentPrefix = "ПС",
                ContractNumber = 0,
                InvoiceNumber = 0,
                PaymentNumber = 0
            });
            context.Users.AddOrUpdate(u => u.Id, new User
            {
                Id = Guid.Parse(GuidDefault),
                Name = "admin",
                Email = "admin@admin.com",
                Password = "21232f297a57a5a743894a0e4a801fc3",
                IsActive = true,
                Language = eARMSystemLanguage.Ukrainian
            });

            context.Rates.AddOrUpdate(u => u.Id,
                new Rate {Id = Guid.NewGuid(), Name = "A", RateMin = 95, RateMax = 100, Mark = 5},
                new Rate {Id = Guid.NewGuid(), Name = "B", RateMin = 85, RateMax = 94, Mark = 4},
                new Rate {Id = Guid.NewGuid(), Name = "C", RateMin = 75, RateMax = 84, Mark = 4},
                new Rate {Id = Guid.NewGuid(), Name = "D", RateMin = 70, RateMax = 74, Mark = 3},
                new Rate {Id = Guid.NewGuid(), Name = "E", RateMin = 60, RateMax = 69, Mark = 3},
                new Rate {Id = Guid.NewGuid(), Name = "F", RateMin = 0, RateMax = 60, Mark = 2}
                );
        }
    }
}