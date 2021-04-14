namespace MyRecipes.Services.Interfaces
{
    public interface IRecipeLikesService
    {
        void Add(int recipeId, int userId);
        void Remove(int recipeId, int userId);
    }
}
