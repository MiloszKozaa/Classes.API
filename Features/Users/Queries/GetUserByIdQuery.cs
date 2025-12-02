using Classes.Dtos;
using MediatR;

namespace Classes.Features.Users.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<UserDTO>;
}