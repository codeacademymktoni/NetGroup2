using System;

namespace MyRecipes.ViewModels
{
    public class RecipeCommentModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
    }
}
