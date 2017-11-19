namespace DAL
{
    using System.Data.Entity;

    public class CustomDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<DevComDbContext>
    {
        protected override void Seed(DevComDbContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }

    public class CustomDropCreateDatabaseAlways : DropCreateDatabaseAlways<DevComDbContext>
    {
        protected override void Seed(DevComDbContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }

    public class CustomCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<DevComDbContext>
    {
        protected override void Seed(DevComDbContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }
}
