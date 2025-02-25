﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipebot.Server.Controllers;
using Recipebot.Server.Data;
using Recipebot.Server.Data.Repositories;
using Recipebot.Shared;
using Recipebot.Shared.Common;
using Recipebot.Shared.ListComponent;
using Recipebot.Shared.RecipeComponent;
using Recipebot.Shared.SubscriptionComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Data;
using UnitTests.MockObjects;
using Xunit;

namespace UnitTests.Controllers
{
    public class ListControllerTests : IDisposable
    {
        public AbstractListFactory ListFactory;
        public ApplicationDbContext Db;
        public IUserState UserState;
        ILogger<ISubscriberState> StateLogger;
        ISubscriberState SubscriberState;
        IListRepository ListRepository;
        IRecipeDTO RecipeDTO;
        IListService ListService;
        IListDTO ListDTO;
        IListDayDTO ListDayDTO;
        IListBuilder ListBuilder;
        HttpClient Http;
        ILogger<ListController> Logger;
        ListController ListController;
        IListGeneratorDTO GeneratedList;

        public ListControllerTests()
        {
            Db = new MockDbContext().Context;
            UserState = new MockUserState();
            StateLogger = new LoggerFactory().CreateLogger<ISubscriberState>();
            SubscriberState = new SubscriberState(StateLogger);
            ListFactory = new ListFactory();
            ListRepository = new ListRepository(Db, UserState,ListFactory);
            RecipeDTO = new RecipeDTO();
            Http = new HttpClient();
            ListDayDTO = new ListDayDTO();
            ListDTO = new ListDTO();
            ListBuilder = new ListBuilder(ListDayDTO, RecipeDTO, ListDTO);
            ListService = new ListService(ListBuilder, Http, ListDayDTO, ListDTO, ListRepository, SubscriberState);
            Logger = new LoggerFactory().CreateLogger<ListController>();
            ListController = new ListController(Logger, ListService, ListDayDTO);
            GeneratedList = new MockListObject().GeneratedList;
        }

        public void Dispose()
        {
            Http.Dispose();
            GC.SuppressFinalize(this);
        }

        [Fact]
        public async Task GenerateRandomDay_NoParameters_ShouldReturnDayDTO()
        {
            var result = await ListController.GenerateRandomDay();

            Assert.IsAssignableFrom<IListDayDTO>(result);
        }

        [Fact]
        public async Task CreateList_WithValidListGeneratorDTO_ShouldReturnHttpResponse()
        {
            var result = await ListController.CreateList((ListGeneratorDTO)GeneratedList);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetRandomRecipeByType_WithValidType_ShouldReturnRecipeDTO()
        {
            var result = await ListController.GetRandomRecipeByType("Breakfast");

            Assert.IsAssignableFrom<IRecipeDTO>(result);
        }
        [Fact]
        public async Task GetRandomRecipeByType_WithInvalidType_ShouldReturnRecipeDTO()
        {
            var result = await ListController.GetRandomRecipeByType("Supper");

            Assert.IsAssignableFrom<IRecipeDTO>(result);
        }
    }
}
