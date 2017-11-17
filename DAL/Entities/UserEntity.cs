namespace DAL.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class UserEntity : IdentityUser
    {
        public string TestProperty { get; set; }
    }
}
