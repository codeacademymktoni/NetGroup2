namespace MyRecipes.ViewModels
{
    public class RecipeDetailsDataModel
    {
        public RecipeDetailsModel RecipeDetails { get; set; }
        public RecipeSidebarDataModel SidebarData { get; set; } = new RecipeSidebarDataModel();
    }
}
