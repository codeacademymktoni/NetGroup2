using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyRecipes.Common.Options;
using MyRecipes.Mappings;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System.Linq;

namespace MyRecipes.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IRecipesService _service;
        private readonly SidebarConfig _sidebarConfig;

        public SidebarService(IRecipesService service, IOptions<SidebarConfig> sidebarConfig)
        {
            _service = service;
            _sidebarConfig = sidebarConfig.Value;
        }

        public RecipeSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new RecipeSidebarDataModel();

            var mostRecentRecipes = _service.GetMostRecentRecipes(_sidebarConfig.MostRecentRecipesCount);
            var topRecipes = _service.GetTopRecipes(_sidebarConfig.TopRecipesCount);

            sidebarDataModel.MostRecentRecipes = mostRecentRecipes.Select(x => x.ToRecipeSidebarModel()).ToList();
            sidebarDataModel.TopRecipes = topRecipes.Select(x => x.ToRecipeSidebarModel()).ToList();

            return sidebarDataModel;
        }
    }
}
