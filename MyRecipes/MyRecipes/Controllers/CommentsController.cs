using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;

namespace MyRecipes.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {
            var request = HttpContext.Request;
            var userId = int.Parse(User.FindFirst("Id").Value);

            _commentsService.Add(commentCreateModel.Comment, commentCreateModel.RecipeId, userId);

            return RedirectToAction("Details", "Recipes", new { id = commentCreateModel.RecipeId });
        }
    }
}
