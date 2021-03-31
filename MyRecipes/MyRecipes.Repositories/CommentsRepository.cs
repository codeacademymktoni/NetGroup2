using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;

namespace MyRecipes.Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(MyRecipesDbContext context) : base(context)
        {

        }
    }
}
