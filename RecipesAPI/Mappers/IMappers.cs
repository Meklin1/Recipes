﻿using ApiCommons.DTOs;
using RecipesAPI.Models;
using System.Security.Principal;

namespace RecipesAPI.Mappers
{
    public interface IMappers
    {
        public Recipe ToRecipe(RecipeRequest recipeRequest, long userId);

        public RecipeResponse ToRecipeResponse(Recipe recipe);

        public RecipeResponse ToRecipeResponseOnCreate(Recipe recipe);

        public Ingredient ToIngredient(IngredientRequest ingredientRequest);

        public IngredientResponse ToIngredientResponse(Ingredient ingredient);

        public Step ToStep(StepRequest stepRequest);

        public StepResponse ToStepResponse(Step step);

        public User ToUser(UserRequest userRequest);

        public UserResponse ToUserResponse(User user);

        public LogInResponse ToLogInResponse(string token);
    }
}
