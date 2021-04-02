namespace MyRecipes.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int recipeId, int userId);
    }
}
