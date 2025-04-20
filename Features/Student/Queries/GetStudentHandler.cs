using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;
using static Classes.Features.Student.Queries.GetStudent;

namespace Classes.Features.Student.Queries
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDTO?>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDTO?> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentWithDependenciesAsync(request.Id, cancellationToken);

            if (student == null) 
            {
                throw new Exception("Student not found");
            }

            return StudentDTO.From(student);
        }
    }
}