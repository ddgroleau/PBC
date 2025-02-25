﻿using Recipebot.Shared.ListComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipebot.Shared.DOM_Events.ComponentEvents
{
    public interface IListGeneratorEvent
    {
        public ILazor Lazor { get; set; }
        public IListGeneratorDTO ListGeneratorDTO { get; set; }
        public Task<IListGeneratorDTO> SubmitList();
        public Task<IListGeneratorDTO> AddDay();
        public IListGeneratorDTO RemoveDay();
    }
}
