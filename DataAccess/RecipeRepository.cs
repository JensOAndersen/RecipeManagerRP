using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RecipeRepository : CommonDBAccess
    {
        IngredientRepository ingredientRepository;
        IngredientsInRecipeRepository IiRRepository;

        public RecipeRepository()
        {
            ingredientRepository = new IngredientRepository();
            IiRRepository = new IngredientsInRecipeRepository();
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

        public void DeleteRecipe(int id)
        {
            string query = $"DELETE FROM Recipes WHERE Id = {id};";

            ExecuteNonQuery(query);
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

        public void NewRecipe(Recipe recipe)
        {
            string query =
                "INSERT INTO Recipes (Name, Description) output INSERTED.Id " +
                "VALUES " +
                $"('{recipe.Name}','{recipe.Description}');";

            int newId = ExecuteNonQueryScalar(query);

            IiRRepository.AddNewIngredientInRecipe(recipe.Ingredients, newId);
        }
    }
}
