using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Models;
using MediatR;

namespace Classes.Features.Student.Queries
{
    public class GetStudent
    {
         public record GetStudentQuery(Guid Id) : IRequest<StudentDTO>;
    }
}