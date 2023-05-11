using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Tomi.Application.ApiResponse;
using Tomi.Application.Auth.Models;
using Tomi.Application.Services;
using Tomi.Domain.Entities;
using Tomi.Domain.Settings;

namespace Tomi.Application.Auth.Commands
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateRequest, Response<AuthenticateResponse>>
    {
        private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IOptions<JwtSettings> _jwtSettings;

		public AuthenticateCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings;
		}

		public async Task<Response<AuthenticateResponse>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return new Response<AuthenticateResponse>(message: "Account not registered");
			}
			var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
			if (!result.Succeeded)
			{
				return new Response<AuthenticateResponse>(message: "Password wrong");
			}

			var tokenService = new TokenService(_jwtSettings); // Inject JwtSettings
			var token = tokenService.GenerateToken(user);

			AuthenticateResponse response = new AuthenticateResponse();
			response.Token = token;
			response.FirstName = user.FirstName;
			response.LastName = user.LastName;
			response.Email = user.Email;
			response.UserId = user.UserId; // UserId is now coming from the token

			return new Response<AuthenticateResponse>(response, $"Authenticated {user.UserName}");
        }
    }
}
