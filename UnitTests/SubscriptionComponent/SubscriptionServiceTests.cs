﻿using Microsoft.Extensions.Logging;
using PBC.Shared;
using PBC.Shared.Common;
using PBC.Shared.RecipeComponent;
using PBC.Shared.SubscriptionComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.SubscriptionComponent
{
    public class SubscriptionServiceFixture : IDisposable
    {
        IRecipeServiceDTO RecipeServiceDTO;
        IBuilder<IRecipeServiceDTO, IRecipeDTO> RecipeBuilder;
        IRecipeDTO RecipeDTO;
        Recipe Recipe;
        RecipeSubscription Subscription;
        IFactory<RecipeSubscription> SubscriptionFactory;
        public ILogger<ISubscriberState> StateLogger;
        public ISubscriptionRepository SubscriptionRepository;
        public ISubscriberState SubscriberState;
        public ISubscriptionService SubscriptionService;

        public SubscriptionServiceFixture()
        {
            RecipeDTO = new RecipeDTO();
            RecipeServiceDTO = new RecipeServiceDTO();
            RecipeBuilder = new RecipeBuilder(RecipeServiceDTO, RecipeDTO);
            Recipe = new Recipe();
            Subscription = new RecipeSubscription();
            SubscriptionFactory = new SubscriptionFactory(Subscription, Recipe);
            StateLogger = new LoggerFactory().CreateLogger<ISubscriberState>();
            SubscriptionRepository = new SubscriptionRepository(SubscriptionFactory);
            SubscriberState = new SubscriberState(StateLogger);
            SubscriptionService = new SubscriptionService(SubscriberState, SubscriptionRepository, RecipeBuilder);
        }

        public void Dispose()
        {
            RecipeDTO = new RecipeDTO();
            RecipeServiceDTO = new RecipeServiceDTO();
            RecipeBuilder = new RecipeBuilder(RecipeServiceDTO, RecipeDTO);
            Recipe = new Recipe();
            Subscription = new RecipeSubscription();
            SubscriptionFactory = new SubscriptionFactory(Subscription, Recipe);
            StateLogger = new LoggerFactory().CreateLogger<ISubscriberState>();
            SubscriptionRepository = new SubscriptionRepository(SubscriptionFactory);
            SubscriberState = new SubscriberState(StateLogger);
            SubscriptionService = new SubscriptionService(SubscriberState, SubscriptionRepository, RecipeBuilder);
        }
    }

    public class SubscriptionServiceTests : IClassFixture<SubscriptionServiceFixture>
    {
        private readonly SubscriptionServiceFixture Fixture;
        public SubscriptionServiceTests(SubscriptionServiceFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CreateSubscription_WithValidId_ShouldNotifyState()
        {
            Fixture.SubscriptionService.CreateSubscription(1); // This will notify the state object to change its HasChanged flag to true.
            Task result = Fixture.SubscriberState.GetRecipeSubscriptions(1); // This will attempt to send an HTTP request if HasChanged is true.
            Assert.ThrowsAsync<HttpRequestException>(() => result); // This will test that CreateSubscription updated the state object so that it will send an HTTP request to get its new state.
        }
        [Fact]
        public void UpdateSubscription_WithValidId_ShouldNotifyState()
        {
            Fixture.SubscriptionService.UpdateSubscription(1);
            Task result = Fixture.SubscriberState.GetRecipeSubscriptions(1);
            Assert.ThrowsAsync<HttpRequestException>(() => result);
        }

        [Fact]
        public void GetSubscriptions_WithValidId_ShouldReturnRecipes()
        {
            var result = Fixture.SubscriptionService.GetUserRecipes(123);
            Assert.IsAssignableFrom<IEnumerable<IRecipeDTO>>(result);
        }

    }
}
