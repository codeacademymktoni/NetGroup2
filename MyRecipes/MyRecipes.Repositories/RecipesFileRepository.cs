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
        const string Path = "Recipes.txt";

        public RecipesFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
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

        public void Add(Recipe recipe)
        {
            recipe.Id = GenerateId();
            Recipes.Add(recipe);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Recipes.Any())
            {
                maxId = Recipes.Max(x => x.Id);
            }

            return maxId + 1;
        }
        private void SaveChanges()
        {
            var serialzed = JsonConvert.SerializeObject(Recipes);
            File.WriteAllText(Path, serialzed);
        }

        public List<Recipe> GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
