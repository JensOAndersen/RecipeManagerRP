using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class RecipeRepository: CommonDBAccess
    {
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
