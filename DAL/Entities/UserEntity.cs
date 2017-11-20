namespace DAL.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserEntity : IdentityUser
    {
        public UserEntity()
        {
            Notes = new HashSet<UserNoteEntity>();
        }

        public UserEntity(string name) : base(name)
        {
            Notes = new HashSet<UserNoteEntity>();
        }

        public override string Id { get; set; }

        public virtual ICollection<UserNoteEntity> Notes { get; set; }
    }
}
