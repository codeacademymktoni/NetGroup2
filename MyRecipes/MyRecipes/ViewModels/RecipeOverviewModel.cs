namespace MyRecipes.ViewModels
{
    public class RecipeOverviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public string RecipeType { get; set; }
    }
}
