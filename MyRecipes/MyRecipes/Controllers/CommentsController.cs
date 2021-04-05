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
            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.RecipeId, userId);

            if (response.IsSuccessful)
            {
                return RedirectToAction("Details", "Recipes", new { id = commentCreateModel.RecipeId });
            }
            else
            {
                return RedirectToAction("ActionNonSuccessful", "Info", new { Message = response.Message });
            }
        }
    }
}
