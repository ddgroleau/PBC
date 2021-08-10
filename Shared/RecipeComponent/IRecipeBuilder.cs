﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.RecipeComponent
{
    public interface IRecipeBuilder
    {
        public IRecipeServiceDTO Build(IRecipeDTO recipeDTO);
        public IRecipeDTO Build(IRecipeServiceDTO recipeServiceDTO);
    }
}
