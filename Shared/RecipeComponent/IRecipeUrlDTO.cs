﻿using Recipebot.Shared.DOM_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Recipebot.Shared.RecipeComponent
{
    public interface IRecipeUrlDTO
    {
        public string URL { get; set; }
    }
}
