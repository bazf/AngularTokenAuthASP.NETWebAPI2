namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NotesAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // "true" for test purpose
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NotesAppContext context)
        {
            DefaultData.Seed(context);
        }
    }
}
