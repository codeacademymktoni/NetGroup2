namespace MyRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public string Description { get; set; }
    }
}
