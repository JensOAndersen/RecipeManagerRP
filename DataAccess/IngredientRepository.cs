using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities;

namespace DataAccess
{
    public class IngredientRepository : CommonDBAccess
    {
        public List<Ingredient> GetAllIngredients()
        {
            string q = "SELECT * FROM Ingredients";
            List<Ingredient> ingredients = new List<Ingredient>();

            DataTable dt = ExecuteQuery(q);

            foreach (DataRow row in dt.Rows)
            {
                ingredients.Add(
                    new Ingredient()
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        Calories = (int)row["Calories"]
                    }
                );
            }

            return ingredients;
        }

        public int NewIngredient(Ingredient ingredient)
        {
            return 0;
        }
    }
}
