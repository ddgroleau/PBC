﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipebot.Shared.RecipeComponent
{
    public class RecipeTypes
    {
        private Dictionary<string, string> Types { get; } = new Dictionary<string, string>()
        {
            {"Breakfast","Breakfast"},
            {"Lunch","Lunch" },
            { "Dinner","Dinner" },
            { "Snack","Snack" },
            { "Beverage","Beverage"}
        };

        public string GetRecipeType(string type)
        {
            try
            {
                return Types[type];
            }
            catch (KeyNotFoundException)
            {
                return "Invalid";
            }
        }
    }
}
