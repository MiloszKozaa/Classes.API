using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Users.Commands
{
    public record RegisterCommand(string Username, string Email, string Password) : IRequest<UserDTO>;

}