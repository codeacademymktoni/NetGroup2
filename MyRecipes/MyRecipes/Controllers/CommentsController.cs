using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Mappings;
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
        public IActionResult Add([FromBody]CommentCreateRequestModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.RecipeId, userId);

            if (response.Status.IsSuccessful)
            {
                return Ok(response.Comment.ToCommentModel());
            }
            else
            {
                return BadRequest(new { Message = response.Status.Message });
            }
        }


        [Authorize]
        public IActionResult Delete(int id)
        {
            var comment = _commentsService.GetById(id);

            if (comment == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            if (comment.UserId != int.Parse(User.FindFirst("Id").Value))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }

            _commentsService.Delete(comment);

            return RedirectToAction("Details", "Recipes", new { id = comment.RecipeId });
        }
    }
}
