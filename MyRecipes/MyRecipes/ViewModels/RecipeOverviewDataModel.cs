using System.Collections.Generic;

namespace MyRecipes.ViewModels
{
    public class RecipeOverviewDataModel
    {
        public List<RecipeOverviewModel> OverviewRecipes { get; set; }
        public string SidebarData{ get; set; }
    }
}
