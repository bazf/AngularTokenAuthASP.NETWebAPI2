namespace DAL.Configurations
{
    using DAL.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class UserNoteEntityConfiguration : EntityTypeConfiguration<UserNoteEntity>
    {
        public UserNoteEntityConfiguration()
        {
            ToTable("user_notes");
        }
    }
}
