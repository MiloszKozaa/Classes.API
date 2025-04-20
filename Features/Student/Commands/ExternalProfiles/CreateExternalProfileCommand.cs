using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Student.Commands.ExternalProfiles
{
    public class CreateExternalProfileCommand
    {
        public record CreateExternalProfile(Guid studentId, string username, string name, string link) : IRequest<StudentDTO>;
    }
}