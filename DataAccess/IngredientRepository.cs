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
