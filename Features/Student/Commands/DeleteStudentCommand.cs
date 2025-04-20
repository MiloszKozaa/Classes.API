using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Classes.Features.Student.Commands
{
    public class DeleteStudentCommand
    {
        public record DeleteStudent(Guid Id) : IRequest;
    }
}