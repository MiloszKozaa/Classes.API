using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Student.Queries
{
    public class GetStudentsFiltered
    {
        public record GetStudentFilteredQuery(string? Search) : IRequest<List<StudentDTO>>;
    }
}