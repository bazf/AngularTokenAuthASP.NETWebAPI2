namespace DAL
{
    using DAL.Configurations;
    using DAL.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

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
            modelBuilder.Configurations.Add(new UserNoteEntityConfiguration());

            ConfigureIdentityTables(modelBuilder);
        }

        private void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("user_claims");
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}