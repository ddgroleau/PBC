﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.RecipeComponent
{
    public interface IRecipeDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
        public string NewIngredient { get; set; }
        public string NewInstruction { get; set; }
        public void AddIngredient();
        public void AddInstruction();
        public void ResetRecipe();
    }
}
