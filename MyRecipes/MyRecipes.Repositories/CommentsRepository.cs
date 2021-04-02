using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(MyRecipesDbContext context) : base(context)
        {
            
        }

        public List<Comment> GetCommentByUserId(int userId)
        {
            var comments = _context.Comments.Where(x => x.UserId == userId).ToList();
            return comments;
        }
    }
}
