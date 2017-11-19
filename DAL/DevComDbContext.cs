namespace DAL
{
    using DAL.Configurations;
    using DAL.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class DevComDbContext : IdentityDbContext<UserEntity>
    {
        public DevComDbContext()
            : base("name=DevComDbContext")
        {
            //Database.SetInitializer(new CustomCreateDatabaseIfNotExists());
            Database.SetInitializer(new CustomDropCreateDatabaseAlways());
            //Database.SetInitializer(new CustomDropCreateDatabaseIfModelChanges());
        }

        public virtual DbSet<UserNoteEntity> UserNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);

            modelBuilder.Configurations.Add(new UserEntityConfiguration());

            ConfigureIdentityTables(modelBuilder);
        }

        private void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("user_claims");
        }
    }
}