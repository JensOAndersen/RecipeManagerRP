using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Recipes
{
    public class CreateModel : PageModel
    {

        private IngredientRepository ingredientRepository;
        private RecipeRepository recipeRepository;

        [BindProperty]
        public Recipe Recipe { get; set; }

        public CreateModel()
        {
            ingredientRepository = new IngredientRepository();
            recipeRepository = new RecipeRepository();

        }

        public void OnGet()
        {

        }

        public void OnGetRecipe()
        {

        }

    }
}