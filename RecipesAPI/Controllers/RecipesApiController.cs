/*
 * Recipe Sharing App API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using RecipesAPI.Filters;
using RecipesAPI.Services.Interfaces;
using RecipesAPI.Services;
using RecipesAPI.Mappers;
using RecipesAPI.Models;
using ApiCommons.DTOs;

    namespace IO.Swagger.Controllers
    {
        /// <summary>
        /// 
        /// </summary>
        [ApiController]
        public class RecipesApiController : ControllerBase
        {
            private readonly IRecipeService _recipeService;
            private readonly IMappers _mappers;

            public RecipesApiController (IRecipeService recipeService, IMappers mappers)
            {
                _recipeService = recipeService;
                _mappers = mappers;
            }

            /// <summary>
            /// Delete a recipe by ID
            /// </summary>
            /// <param name="id"></param>
            /// <response code="204">Recipe deleted</response>
            [HttpDelete]
            [Route("/v1/recipe/{id}")]
            [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
            [SwaggerOperation("RecipeIdDelete")]
            public virtual IActionResult RecipeIdDelete([FromRoute][Required] long? id)
            {
                //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
                // return StatusCode(204);

                throw new NotImplementedException();
            }

        /// <summary>
        /// Get a recipe by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">A recipe</response>
        [HttpGet]
        [Route("/v1/recipe/{id}")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("RecipeIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(RecipeResponse), description: "A recipe")]
        public async Task<IActionResult> RecipeIdGet([FromRoute][Required] long id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            return Ok(_mappers.ToRecipeResponse(recipe));
        }

        /// <summary>
        /// Update a recipe by ID
        /// </summary>
        /// <param name="body"></param>
        /// <param name="id"></param>
        /// <response code="200">Recipe updated</response>
        [HttpPut]
        [Route("/v1/recipe/{id}")]
        [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("RecipeIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(RecipeResponse), description: "Recipe updated")]
        public virtual IActionResult RecipeIdPut([FromBody] RecipeRequest body, [FromRoute][Required] long? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Recipe));
            string exampleJson = null;
            exampleJson = "{\n  \"level\" : \"easy\",\n  \"description\" : \"description\",\n  \"created_at\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"userId\" : 6,\n  \"steps\" : [ {\n    \"phase\" : \"prep\",\n    \"step_number\" : 2,\n    \"description\" : \"description\",\n    \"id\" : 5\n  }, {\n    \"phase\" : \"prep\",\n    \"step_number\" : 2,\n    \"description\" : \"description\",\n    \"id\" : 5\n  } ],\n  \"version\" : 2,\n  \"duration\" : 9,\n  \"servings\" : 7,\n  \"updated_at\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"name\" : \"name\",\n  \"ingredients\" : [ {\n    \"amount\" : 5,\n    \"name\" : \"name\",\n    \"id\" : 1,\n    \"measurement\" : \"kg\"\n  }, {\n    \"amount\" : 5,\n    \"name\" : \"name\",\n    \"id\" : 1,\n    \"measurement\" : \"kg\"\n  } ],\n  \"id\" : 0,\n  \"energy\" : 3\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<RecipeResponse>(exampleJson)
            : default(RecipeResponse);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a new recipe
        /// </summary>
        /// <param name="body"></param>
        /// <response code="201">Recipe created</response>
        [HttpPost]
        [Route("/v1/recipe")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("RecipePost")]
        [SwaggerResponse(statusCode: 201, type: typeof(RecipeResponse), description: "Recipe created")]
        public async Task<IActionResult> RecipePost([FromBody] RecipeRequest recipeDTO)
        {
            var recipe = await _recipeService.CreateRecipesAsync(_mappers.ToRecipe(recipeDTO));
            return Ok(_mappers.ToRecipeResponseOnCreate(recipe));
        }

        /// <summary>
        /// List recipes
        /// </summary>
        /// <param name="filter">Filter criteria for recipes</param>
        /// <response code="200">A list of recipes</response>
        [HttpGet]
        [Route("/v1/recipes")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("RecipesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<RecipeResponse>), description: "A list of recipes")]
        public async Task<IActionResult> RecipesGet([FromQuery] RecipeFilter filter)
        {
            var recipes = await _recipeService.GetRecipesAsync(filter);
            var recipeDTOs = recipes.Select(recipe => _mappers.ToRecipeResponse(recipe));
            return Ok(recipeDTOs);
        }
    }
}