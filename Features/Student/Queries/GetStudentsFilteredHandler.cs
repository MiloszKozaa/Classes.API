using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            private readonly IHttpContextAccessor _httpContextAccessor;

        public GetStudentQueryFilteredHandler(IStudentRepository studentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _studentRepository = studentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<StudentDTO>> Handle(GetStudentFilteredQuery request, CancellationToken cancellationToken)
        {
    

            var userId = AuthHelpers.GetUserIdWithQueryPriority(
                    request.userId, 
                    _httpContextAccessor.HttpContext!
                );

            var students = await _studentRepository.GetAllByUserIdAsync(userId, cancellationToken);

            return StudentDTO.From(students.Where(s => (request.Search == null || request.Search == string.Empty) ? true :
                    s.FirstName.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.LastName.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.Username.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.Email.Contains(request.Search, StringComparison.OrdinalIgnoreCase) ||
                    s.PhoneNumber.Contains(request.Search, StringComparison.OrdinalIgnoreCase)  )
                .ToList());
        }
    }
}