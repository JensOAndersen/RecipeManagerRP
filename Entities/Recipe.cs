using System;
using System.Collections.Generic;

namespace Entities
{
    public class Recipe
    {
        private string name;
        private string description;
        private int id;
        private List<Ingredient> list;

        public List<Ingredient> Ingredients
        {
            get { return list; }
            set { list = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
