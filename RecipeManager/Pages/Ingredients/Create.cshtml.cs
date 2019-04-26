using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeManager.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}