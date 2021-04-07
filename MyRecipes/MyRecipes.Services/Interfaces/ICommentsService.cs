using MyRecipes.Models;
using MyRecipes.Services.DtoModels;

namespace MyRecipes.Services.Interfaces
{
    public interface ICommentsService
    {
        StatusModel Add(string comment, int recipeId, int userId);
        Comment GetById(int id);
        void Delete(Comment comment);
    }
}
