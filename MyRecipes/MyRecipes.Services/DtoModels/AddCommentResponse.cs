using MyRecipes.Models;

namespace MyRecipes.Services.DtoModels
{
    public class AddCommentResponse
    {
        public StatusModel Status { get; set; } = new StatusModel();
        public Comment Comment { get; set; }
    }
}
