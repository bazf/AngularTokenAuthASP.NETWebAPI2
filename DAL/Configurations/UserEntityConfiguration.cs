namespace DAL.Configurations
{
    using DAL.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            ToTable("users");

            Property(u => u.UserName).HasMaxLength(128);
            Property(u => u.Email).HasMaxLength(128);
        }
    }
}
