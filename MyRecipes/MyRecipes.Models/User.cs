using System;
using System.Collections.Generic;
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

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public List<Comment> Comments { get; set; }

        public List<RecipeLike> RecipeLikes { get; set; }
    }
}
