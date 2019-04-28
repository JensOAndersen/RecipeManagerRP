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
        private List<Ingredient> Ingredients;

        public List<Ingredient> AllIngredients { get; set; }

        public SelectIngredientsModel()
        {
            ingredientRepository = new IngredientRepository();

            AllIngredients = ingredientRepository.GetAllIngredients();
        }

        public IActionResult OnPost()
        {
            var ids = Request.Form["ingredientId"];

            //Ingredients = new List<Ingredient>();

            //foreach (var id in ids)
            //{
            //    if (int.TryParse(id, out int res))
            //    {
            //        Ingredients.Add(ingredientRepository.GetIngredient(id));
            //    }
            //}

            return RedirectToPage("Create", "Recipe", ids);
        }
    }
}