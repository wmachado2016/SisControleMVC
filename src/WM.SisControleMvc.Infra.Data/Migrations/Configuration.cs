using System.Data.Entity.Migrations;
using WM.SisControleMvc.Infra.Data.Context;

namespace WM.SisControleMvc.Infra.Data.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<SisControleMvcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SisControleMvcContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

