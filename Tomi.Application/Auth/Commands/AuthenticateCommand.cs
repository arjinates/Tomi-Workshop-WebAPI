using MediatR;
using Tomi.Application.Auth.Models;

namespace Tomi.Application.Auth.Commands
{
    public class AuthenticateCommand : IRequest<AuthenticateResponse>
    {
    }
}
