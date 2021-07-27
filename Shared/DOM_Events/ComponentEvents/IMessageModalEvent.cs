﻿using PBC.Shared.RecipeComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.DOM_Events.ComponentEvents
{
    public interface IMessageModalEvent
    {
        public void HandleClick(ILazor e);
        public void DeleteRecipe(IRecipeDTO recipeDTO, ILazor lazor);
    }
}
