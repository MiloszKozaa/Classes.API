using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;
using static Classes.Features.Student.Queries.GetStudentsFiltered;

namespace Classes.Features.Student.Queries
{
    public class GetStudentQueryFilteredHandler : IRequestHandler<GetStudentFilteredQuery, List<StudentDTO>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentQueryFilteredHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDTO>> Handle(GetStudentFilteredQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync(cancellationToken);
            
            // return students.ToList();

            return StudentDTO.From(students.Where(s => request.Search == null ? true :
                    s.FirstName.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.LastName.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.Username.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.Email.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.PhoneNumber.Contains(request.Search, StringComparison.OrdinalIgnoreCase)  )
                .ToList());
        }
    }
}