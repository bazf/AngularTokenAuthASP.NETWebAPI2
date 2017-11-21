namespace Core.DTOs.UserNoteDTOs
{
    using Core.DTOs.UserDTOs;

    public class UserNoteDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }
    }
}
