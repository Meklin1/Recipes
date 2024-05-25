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
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMappers _mappers;

        public AuthApiController(IAuthService authService, IMappers mappers)
        {
            _authService = authService;
            _mappers = mappers;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">A JWT Token</response>
        [HttpPost]
        [Route("/v1/auth/login")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        [SwaggerOperation("UserIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserResponse), description: "A user")]
        public async Task<IActionResult> UserIdGet([FromBody] LogInRequest logInDTO)
        {
            var token = await _authService.LogInAsync(logInDTO.Email, logInDTO.Password);
            return Ok(_mappers.ToLogInResponse(token));
        }
    }
}