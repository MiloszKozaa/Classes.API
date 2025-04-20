using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Student.Commands.ExternalProfiles
{
    public class DeleteExternalProfileCommand
    {
        public record DeleteExternalProfile(Guid Id, Guid ExternalProfileId) : IRequest<StudentDTO>;
    }
}