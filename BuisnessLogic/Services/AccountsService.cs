using AutoMapper;
using BuisnessLogic.DTOs.Accounts;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtService jwtService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;
        private readonly CinemaDbContext ctx;

        public AccountsService(
            IJwtService jwtService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            CinemaDbContext ctx)

        {
            this.jwtService = jwtService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.ctx = ctx;
        }
        public async Task<LoginResponse> Login(LoginModel model, string? ipAddress)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid email or password.", HttpStatusCode.BadRequest);

            //await signInManager.SignInAsync(user, true);
            var refreshToken = jwtService.GenerateRefreshToken(ipAddress ?? "unknown");
            user.RefreshTokens.Add(refreshToken);
            // Save?
            await ctx.SaveChangesAsync();
            return new()
            {
                AccessToken = jwtService.GenerateToken(jwtService.GetClaims(user)),
                RefreshToken = refreshToken.Token
            };

        }
        public async Task<LoginResponse> Refresh(RefreshRequest model, string? ipAddress)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == model.RefreshToken));
            if (user == null)
                throw new HttpException("Invalid user.", HttpStatusCode.Unauthorized);

            var token = ctx.RefreshTokens.Single(x => x.Token == model.RefreshToken);

            if (!token.IsActive)
                throw new HttpException("Invalid refresh token", HttpStatusCode.Unauthorized);

            // Revoke old token
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;

            // Generate new tokens
            var newJwt = jwtService.GenerateToken(jwtService.GetClaims(user));
            var newRefresh = jwtService.GenerateRefreshToken(ipAddress ?? "unknown");

            user.RefreshTokens.Add(newRefresh);
            // Save?
            await ctx.SaveChangesAsync();

            return new()
            {
                AccessToken = newJwt,
                RefreshToken = newRefresh.Token
            };
        }
        public async Task Logout(LogoutModel model)
        {
            await signInManager.SignOutAsync();
        }


        public async Task Register(RegisterModel model)
        {
            var user = mapper.Map<User>(model);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new HttpException(result.Errors?.FirstOrDefault()?.Description ?? "Error", HttpStatusCode.BadRequest);
        }
    }
}
