﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PBC.Shared;
using PBC.Shared.RecipeComponent;
using PBC.Shared.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBC.Server.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeDTO _recipeDTO;
        private readonly IAllRecipesScraper _allRecipesScraper;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeDTO recipeDTO, IAllRecipesScraper allRecipesScraper, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeDTO = recipeDTO;
            _allRecipesScraper = allRecipesScraper;
            _recipeService = recipeService;
        }

        [HttpPost("RecipeURL")]
        public IRecipeDTO ProcessRecipeUrl(RecipeUrlDTO urlDTO)
        {
            try
            {
                _logger.LogInformation($"New URL {urlDTO.URL} recieved by RecipeController, PostRecipeUrl method. Timestamp: {DateTime.Now:MM/dd/yyyy HH:mm:ss}.");
                return _allRecipesScraper.ScrapeRecipe(urlDTO.URL, _recipeDTO);
            }
            catch (Exception)
            {
                _logger.LogError($"Failed to scrape {urlDTO.URL} from AllRecipes.com; RecipeController, PostRecipeUrl method.");
            }
            return _recipeDTO;
        }

        [HttpPost("Recipe")]
        public IActionResult CreateOrUpdateRecipe(RecipeDTO recipeDTO)
        {
            try
            {
                _recipeService.CreateRecipe(recipeDTO);
                _logger.LogInformation($"Processing RecipeDTO: \"{recipeDTO.Title}\" at RecipeController, PostRecipe method. Timestamp: {DateTime.Now:MM/dd/yyyy HH:mm:ss}.");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to process RecipeDTO \"{recipeDTO.Title}\" at RecipeController, PostRecipe method. Timestamp: {DateTime.Now:MM/dd/yyyy HH:mm:ss}.", e.Message);
            }
            return BadRequest();
        }  

        [HttpGet("SearchRecipes/{searchText}")]
        public IEnumerable<IRecipeDTO> SearchRecipes(string searchText)
        {
            IEnumerable<IRecipeDTO> recipes = new List<IRecipeDTO>();
            _logger.LogInformation($"Search request received by RecipeController, SearchRecipes method. Search text: {searchText}. Timestamp: {DateTime.Now:MM/dd/yyyy HH:mm:ss}.");
            try
            {
                recipes = _recipeService.SearchRecipes(searchText);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve recipes at RecipeController, SearchRecipes method. Timestamp: {DateTime.Now:MM/dd/yyyy HH:mm:ss}.", e.Message);
            }
            return recipes;
        }
    }
}
