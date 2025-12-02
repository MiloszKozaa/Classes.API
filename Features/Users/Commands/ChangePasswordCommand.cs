using MediatR;

namespace Classes.Features.Auth.Commands.ChangePassword
{
    public record ChangePasswordCommand(Guid UserId, string CurrentPassword, string NewPassword) : IRequest<bool>;
}