using MyRecipes.Mappings;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System.Linq;

namespace MyRecipes.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IRecipesService _service;

        public SidebarService(IRecipesService service)
        {
            _service = service;
        }

        public RecipeSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new RecipeSidebarDataModel();

            var mostRecentRecipes = _service.GetMostRecentRecipes(5);
            var topRecipes = _service.GetTopRecipes(5);

            sidebarDataModel.MostRecentRecipes = mostRecentRecipes.Select(x => x.ToRecipeSidebarModel()).ToList();
            sidebarDataModel.TopRecipes = topRecipes.Select(x => x.ToRecipeSidebarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
