using MediatR;
using Tomi.Application.ApiResponse;

namespace Tomi.Application.Auth.Models
{
    public class RegisterRequest : IRequest<Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
