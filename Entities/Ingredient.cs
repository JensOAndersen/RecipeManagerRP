using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Ingredient
    {
        private int id;
        private string name;
        private IngredientType type;
        private int amount;
        private Unit unit;
        private int recipeId;

        public int RecipeId
        {
            get { return recipeId; }
            set { recipeId = value; }

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        [Required]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [Required]
        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }

        [Required]
        [MinLength(2)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
