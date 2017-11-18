namespace Core.DTOs.UserDTOs
{
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ConfirmPassword { get; set; }
    }
}
