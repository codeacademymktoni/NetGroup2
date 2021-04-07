using System.Collections.Generic;

namespace MyRecipes.ViewModels
{
    public class RecipeSidebarDataModel
    {
        public List<RecipeSidebarModel> TopRecipes { get; set; } = new List<RecipeSidebarModel>();
        public List<RecipeSidebarModel> MostRecentRecipes { get; set; } = new List<RecipeSidebarModel>();
    }
}
