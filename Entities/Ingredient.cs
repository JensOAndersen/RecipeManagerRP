using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Ingredient
    {
        private int id;
        private string name;
        private IngredientType type;
        private Unit amount;
        private string unit;
        private int recipeId;

        public int RecipeId
        {
            get { return recipeId; }
            set { recipeId = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Unit Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
