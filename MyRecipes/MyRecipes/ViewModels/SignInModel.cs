using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class SignInModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$", ErrorMessage = "Password must meet requirements")]
        public string Password { get; set; }
    }
}
