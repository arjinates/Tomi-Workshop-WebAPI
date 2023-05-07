using MediatR;
using Microsoft.AspNetCore.Identity;
using Tomi.Application.ApiResponse;
using Tomi.Application.Auth.Models;
using Tomi.Domain.Entities;

namespace Tomi.Application.Auth.Commands
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateRequest, Response<AuthenticateResponse>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticateCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

            AuthenticateResponse response = new AuthenticateResponse();
            response.Token = "jwt token operation can be improved";
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.Email = user.Email;

            return new Response<AuthenticateResponse>(response, $"Authenticated {user.UserName}");
        }
    }
}
