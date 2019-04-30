using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Ingredient Ingredient { get; set; }

        IngredientRepository ingredientRepository;

        public CreateModel()
        {
            ingredientRepository = new IngredientRepository();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.NewIngredient(Ingredient);
                return Redirect("/Ingredients/Index");
            }
            return Page();
        }
    }
}