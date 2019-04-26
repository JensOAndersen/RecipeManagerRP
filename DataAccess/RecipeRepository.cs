using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RecipeRepository: CommonDBAccess
    {
        IngredientRepository ingredientRepository;
        public RecipeRepository()
        {
            ingredientRepository = new IngredientRepository();
        }
        public List<Recipe> GetAllRecipesWithIngredients()
        {
            List<Recipe> recipes = GetAllRecipes();
            List<Ingredient> fullIngredients = ingredientRepository.GetAllIngredientsFull();


            //recipes.ForEach(x => x.Ingredients.AddRange(fullIngredients.Where(ing => ing.RecipeId == x.Id)));

            foreach (var ingredient in fullIngredients)
            {
                recipes.Where(x => x.Id == ingredient.RecipeId).FirstOrDefault().Ingredients.Add(ingredient);
            }

            return recipes;
        }

        public Recipe GetRecipe(int id)
        {
            return GetAllRecipesWithIngredients().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Recipe> GetAllRecipes()
        {
            var recipes = new List<Recipe>();

            DataTable dtRecipes = ExecuteQuery("SELECT * FROM Recipes");

            foreach (DataRow row in dtRecipes.Rows)
            {
                recipes.Add(new Recipe()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"]
                });
            }

            return recipes;
        }
    }
}
