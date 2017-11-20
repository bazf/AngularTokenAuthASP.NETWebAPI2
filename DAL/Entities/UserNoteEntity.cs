namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserNoteEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [ForeignKey("UserEntity")]
        public string UserId { get; set; }

        public virtual UserEntity UserEntity { get; set; }
    }
}
