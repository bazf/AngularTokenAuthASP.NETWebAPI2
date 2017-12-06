namespace DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;

    public static class DefaultData
    {
        public static void Seed(NotesAppContext context)
        {
            try
            {
                    context.Roles.AddOrUpdate(new IdentityRole("admin"));
                    context.Roles.AddOrUpdate(new IdentityRole("user"));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
