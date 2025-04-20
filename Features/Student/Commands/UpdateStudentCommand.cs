using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Student.Commands
{
    public class UpdateStudentCommand
    {
        public record UpdateStudent(Guid id, string username, string firstName, string lastName, string email, string phoneNumber) : IRequest<StudentDTO>;
    }
}