using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Ingredient
    {
        private int id;
        private string name;
        private int calories;
        private int amount;
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
