﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipebot.Shared.RecipeComponent
{
    public interface IRecipeService
    {
        public Task<int> CreateRecipe(IRecipeDTO RecipeDTO);
        public IEnumerable<IRecipeDTO> SearchRecipes(string searchText);
        public Task<IEnumerable<IRecipeDTO>> GetUserRecipes();
    }
}
