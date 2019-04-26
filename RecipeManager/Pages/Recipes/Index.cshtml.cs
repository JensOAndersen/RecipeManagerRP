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
    public class IndexModel : PageModel
    {
        RecipeRepository repository;
        public List<Recipe> Recipes { get; set; }

        public IndexModel()
        {
            repository = new RecipeRepository();
        }

        public void OnGet()
        {
            Recipes = repository.GetAllRecipes();
        }
    }
}