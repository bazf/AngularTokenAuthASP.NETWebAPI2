namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DevComDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // "true" for test purpose
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DevComDbContext context)
        {
            DefaultData.Seed(context);
        }
    }
}
