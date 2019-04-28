using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities;

namespace DataAccess
{
    public class IngredientRepository : CommonDBAccess
    {
        internal List<Ingredient> GetAllIngredientsFull()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string q =
                "SELECT " +
                "Ingredients.Name AS IngredientName, " +
                "Ingredients.Id AS IngredientId, " +
                "Ingredients.Type, " +
                "IngredientsInRecipes.RecipeId, " +
                "IngredientsInRecipes.Amount, " +
                "IngredientsInRecipes.Unit " +
                "FROM IngredientsInRecipes " +
                "INNER JOIN Ingredients ON IngredientsInRecipes.IngredientId = Ingredients.Id;";

            DataTable ingredientDetails = ExecuteQuery(q);

            foreach (DataRow row in ingredientDetails.Rows)
            {
                ingredients.Add(new Ingredient()
                {
                    Id = (int)row["IngredientId"],
                    RecipeId = (int)row["RecipeId"],
                    Type = (IngredientType)row["Type"],
                    Amount = (int)row["Amount"],
                    Unit = (Unit)row["Unit"],
                    Name = (string)row["IngredientName"]
                });
            }

            return ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            string q = $"SELECT * FROM Ingredients WHERE Id = {id};";

            DataTable dt = ExecuteQuery(q);

            foreach (DataRow row in dt.Rows)
            {
                return new Ingredient()
                {
                    Name = (string)row["Name"],
                    Id = (int)row["Id"],
                    Type = (IngredientType)row["Type"]
                };
            }

            return null;
        }

        public List<Ingredient> GetAllIngredients()
        {
            string q = "SELECT * FROM Ingredients;";
            List<Ingredient> ingredients = new List<Ingredient>();

            DataTable dt = ExecuteQuery(q);

            foreach (DataRow row in dt.Rows)
            {
                ingredients.Add(
                    new Ingredient()
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Type = (IngredientType)((int)row["Type"])
                    }
                );
            }

            return ingredients;
        }

        public int DeleteIngredient(int id)
        {
            string q = $"DELETE FROM Ingredients WHERE Id = {id}";

            return ExecuteNonQuery(q);
        }

        public int NewIngredient(Ingredient ingredient)
        {
            string q = 
                "INSERT INTO Ingredients ([Name],[Type]) " +
                "Values " +
                $"('{ingredient.Name}',${(int)ingredient.Type});";

            return ExecuteNonQuery(q);
        }
    }
}
