using System;

namespace MyRecipes.ViewModels
{
    public class RecipeSidebarModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int Views { get; set; }
    }
}
