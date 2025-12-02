using MediatR;

namespace Classes.Features.Auth.Commands.Login
{
    public record LoginCommand(string Username, string Password) : IRequest<string>;
}