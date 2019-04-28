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
    public class SelectIngredientsModel : PageModel
    {
        private IngredientRepository ingredientRepository;

        public List<Ingredient> AllIngredients { get; set; }

        public void OnGet()
        {
            ingredientRepository = new IngredientRepository();

            AllIngredients = ingredientRepository.GetAllIngredients();
        }

        public IActionResult OnPost()
        {
            var ids = string.Join(',',Request.Form["ingredientId"]);

            return RedirectToPage("Create", new { ing = ids });
        }
    }
}