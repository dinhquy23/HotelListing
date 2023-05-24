﻿using AutoMapper;
using HotelListing.Data;
using HotelListing.Extensions;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<ApiUser> usermanager,
            SignInManager<ApiUser> signInManager,
            ILogger<AccountController> logger,
            IMapper mapper)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;

        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.FirstName;
                var checkExistUser = await _userManager.FindByEmailAsync(user.Email);
                if (checkExistUser != null)
                {
                    return Problem($"User {user.Email} is exist");
                }
                else
                {
                    var result = await _userManager.CreateAsync(user, userDTO.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest($"{result.Errors.FirstOrDefault().Description}");
                    }
                    return Created(user.Id, user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)} method");
                return Problem($"Something went wrong in the {nameof(Register)} method", statusCode: 500);
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation($"Login attempt for {loginDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var checkExistUser = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (checkExistUser != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(checkExistUser, loginDTO.Password, false);
                    if (result.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status200OK, new Responsive("Success", "Login successfully"));
                    }
                    return Unauthorized(loginDTO);
                }
                else
                {
                    return Problem($"User {loginDTO.Email} is not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Login)} method");
                return Problem($"Something went wrong in the {nameof(Login)} method", statusCode: 500);
            }
        }
    }
}
