﻿using PBC.Shared.RecipeComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.SubscriptionComponent
{
    public interface ISubscriptionService
    {
        public void CreateSubscription(int id);
        public void UpdateSubscription(int id);
        public IEnumerable<IRecipeDTO> GetUserRecipes(int userId);

    }
}
