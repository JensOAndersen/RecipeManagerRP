using System;

namespace Entities
{
    public class Recipe
    {
        private string name;
        private string description;

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
