﻿using BuisnessLogic.DTOs.Accounts;
using BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await accountsService.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            await accountsService.Login(model);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutModel model)
        {
            await accountsService.Logout(model);
            return Ok();
        }
    }
}
