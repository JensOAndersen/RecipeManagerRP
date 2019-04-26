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
    public class DetailModel : PageModel
    {
        RecipeRepository repository;

        public Recipe Recipe { get; set; }

        public DetailModel()
        {
            repository = new RecipeRepository();
        }

        public void OnGet(int id)
        {
            Recipe = repository.GetRecipe(id);
        }
    }
}