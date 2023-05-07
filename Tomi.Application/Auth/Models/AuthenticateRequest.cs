using MediatR;
using Tomi.Application.ApiResponse;

namespace Tomi.Application.Auth.Models
{
    public class AuthenticateRequest : IRequest<Response<AuthenticateResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
