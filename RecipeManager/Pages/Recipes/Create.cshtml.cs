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

        public void OnGet(string ing)
        {
            string[] ingredientIds = ing.Split(',');

            Recipe = new Recipe();

            foreach (string sId in ingredientIds)
            {
                if (int.TryParse(sId, out int id))
                {
                    Recipe.Ingredients.Add(ingredientRepository.GetIngredient(id));
                }
            }
        }

        public void OnPost()
        {
            recipeRepository.NewRecipe(Recipe);

            Response.Redirect("/Recipes/");
        }
    }
}