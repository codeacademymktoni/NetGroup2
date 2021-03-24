using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
