
using System;

namespace MyRecipes.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
