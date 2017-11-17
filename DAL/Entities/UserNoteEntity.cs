namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserNoteEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [StringLength(100)]
        public string Text { get; set; }
    }
}
