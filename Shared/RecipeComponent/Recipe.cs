﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBC.Shared.RecipeComponent
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [MaxLength(20)]
        public string RecipeType { get; set; }
        [MaxLength(150)]
        public string URL { get; set; }
        [Required, MaxLength(90)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
