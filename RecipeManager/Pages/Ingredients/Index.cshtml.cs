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
    public class IndexModel : PageModel
    {
        public List<Ingredient> Ingredients { get; set; }

        IngredientRepository repo;
        public IndexModel()
        {
            repo = new IngredientRepository();
        }

        public void OnGet()
        {
            Ingredients = repo.GetAllIngredients();
        }
    }
}