namespace DAL
{
    using System.Data.Entity;

    public class CustomDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<NotesAppContext>
    {
        protected override void Seed(NotesAppContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }

    public class CustomDropCreateDatabaseAlways : DropCreateDatabaseAlways<NotesAppContext>
    {
        protected override void Seed(NotesAppContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }

    public class CustomCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<NotesAppContext>
    {
        protected override void Seed(NotesAppContext context)
        {
            DefaultData.Seed(context);
            base.Seed(context);
        }
    }
}
