using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyRecipes.Repositories
{
    public class RecipesSqlRepository : IRecipesRepository
    {
        //public void Add(Recipe recipe)
        //{
        //    using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipesSql;Trusted_Connection=True; "))
        //    {
        //        cnn.Open();

        //        var query = @"insert into recipes(Title, ImageUrl, Ingredients, Description,Directions) 
        //                        values(@Title, @ImageUrl, @Ingredients, @Description, @Directions)";

        //        var cmd = new SqlCommand(query, cnn);
        //        cmd.Parameters.AddWithValue("@Title", recipe.Title);
        //        cmd.Parameters.AddWithValue("@ImageUrl", recipe.ImageUrl);
        //        cmd.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
        //        cmd.Parameters.AddWithValue("@Description", recipe.Description);
        //        cmd.Parameters.AddWithValue("@Directions", recipe.Directions);

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //demo executing SP in SQL
        public void Add(Recipe recipe)
        {
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipesSql;Trusted_Connection=True; "))
            {
                cnn.Open();

                var cmd = new SqlCommand("InsertRecipe", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", recipe.Title);
                cmd.Parameters.AddWithValue("@ImageUrl", recipe.ImageUrl);
                cmd.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                cmd.Parameters.AddWithValue("@Description", recipe.Description);
                cmd.Parameters.AddWithValue("@Directions", recipe.Directions);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Recipe> GetAll()
        {
            var result = new List<Recipe>();

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipesSql;Trusted_Connection=True; ")) 
            {
                cnn.Open();

                var query = "select * from recipes";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var recipe = new Recipe();

                    recipe.Id = reader.GetInt32(0);
                    recipe.Title = reader.GetString(1);
                    recipe.ImageUrl = reader.GetString(2);
                    recipe.Ingredients = reader.GetString(3);
                    recipe.Directions = reader.GetString(4);
                    recipe.Description = reader.GetString(5);

                    result.Add(recipe);
                }
            }

            return result;
        }

        public List<Recipe> GetByTitle(string title)
        {
            var result = new List<Recipe>();

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipesSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = $"select * from recipes where title = @Title";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", title);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var recipe = new Recipe();

                    recipe.Id = reader.GetInt32(0);
                    recipe.Title = reader.GetString(1);
                    recipe.ImageUrl = reader.GetString(2);
                    recipe.Ingredients = reader.GetString(3);
                    recipe.Directions = reader.GetString(4);
                    recipe.Description = reader.GetString(5);

                    result.Add(recipe);
                }
            }

            return result;
        }

        public Recipe GetById(int id)
        {
            Recipe result = null;

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyRecipesSql;Trusted_Connection=True; "))
            {
                cnn.Open();

                var query = $"select * from recipes where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Recipe();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageUrl = reader.GetString(2);
                    result.Ingredients = reader.GetString(3);
                    result.Directions = reader.GetString(4);
                    result.Description = reader.GetString(5);
                }
            }

            return result;
        }
    }
}
