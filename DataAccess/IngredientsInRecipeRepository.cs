using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    internal class IngredientsInRecipeRepository : CommonDBAccess
    {
        internal void AddNewIngredientInRecipe(List<Ingredient> ingredients, int recipeId)
        {
            string query =
                "INSERT INTO IngredientsInRecipes (IngredientId, RecipeId, Amount, Unit) " +
                "VALUES ";

            for (int i = 0; i < ingredients.Count; i++)
            {
                query += $"({ingredients[i].Id},{recipeId},{ingredients[i].Amount},{(int)ingredients[i].Unit})";

                if (i + 1 < ingredients.Count)
                {
                    query += ",";
                }
            }
            query += ";";

            ExecuteNonQuery(query);
        }
    }
}
