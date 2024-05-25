/*
 * User Sharing App API
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
using RecipesAPI.Filters;
using RecipesAPI.Services.Interfaces;
using RecipesAPI.Mappers;
using RecipesAPI.Models;
using ApiCommons.DTOs;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMappers _mappers;

        public UserApiController(IUserService userService, IMappers mappers)
        {
            _userService = userService;
            _mappers = mappers;
        }


        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">A user</response>
        [HttpGet]
        [Route("/v1/user/{id}")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("UserIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserResponse), description: "A user")]
        public async Task<IActionResult> UserIdGet([FromRoute][Required] long id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(_mappers.ToUserResponse(user));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="body"></param>
        /// <response code="201">User created</response>
        [HttpPost]
        [Route("/v1/user")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("UserPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(UserResponse), description: "User created")]
        public async Task<IActionResult> UserPost([FromBody] UserRequest userDTO)
        {
            var user = await _userService.CreateUserAsync(_mappers.ToUser(userDTO));
            return Ok(_mappers.ToUserResponse(user));
        }
    }
}