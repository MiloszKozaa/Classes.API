using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using Classes.Models;
using MediatR;

namespace Classes.Features.Student.Commands.ExternalProfiles
{
    public class CreateExternalProfileCommandHandler : IRequestHandler<CreateExternalProfileCommand.CreateExternalProfile, StudentDTO>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateExternalProfileCommandHandler(IStudentRepository studentRepository, IHttpContextAccessor httpContextAccessor)
        {
            _studentRepository = studentRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<StudentDTO> Handle(CreateExternalProfileCommand.CreateExternalProfile request, CancellationToken cancellationToken)
        {
            var userId = AuthHelpers.GetUserIdFromToken(
                    _httpContextAccessor.HttpContext!
                );


            var student = await _studentRepository.GetStudentWithDependenciesAsync(request.studentId, cancellationToken); 

            if(student == null)
            {
                throw new Exception("Student not found");
            }

            student.AddExternalProfile(ExternalProfile.Create(request.studentId,  request.username, request.name, request.link, userId));

            await _studentRepository.UpdateAsync(student, cancellationToken);

            return StudentDTO.From(student);
        }
    }
}