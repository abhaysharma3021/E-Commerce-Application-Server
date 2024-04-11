using System.ComponentModel.DataAnnotations;

namespace Server.Core.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
