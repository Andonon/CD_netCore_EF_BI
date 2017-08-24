using System.ComponentModel.DataAnnotations;

namespace brightideas.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name must be betwen 2 and 255 characters", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Alias is required.")]
        [StringLength(255, ErrorMessage = "Alias must be betwen 2 and 255 characters", MinimumLength = 2)]
        public string Alias { get; set; }
        
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "You must use a vaild email address format, this will be your login")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(70, ErrorMessage = "Password must be between 8 and 70 characters.", MinimumLength = 8)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string CPassword { get; set; }
    }
}