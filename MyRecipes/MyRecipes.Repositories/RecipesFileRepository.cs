using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class RecipesFileRepository : IRecipesRepository
    {
        public RecipesFileRepository()
        {
            var path = "Recipes.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            var result = File.ReadAllText(path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Recipe>>(result);
            Recipes = deserialzedList;
        }

        public List<Recipe> Recipes { get; set; }

        public List<Recipe> GetAll()
        {
            return Recipes;
        }

        public Recipe GetById(int id)
        {
            return Recipes.FirstOrDefault(x => x.Id == id);
        }
    }
}
