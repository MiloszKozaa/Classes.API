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

        public CreateExternalProfileCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDTO> Handle(CreateExternalProfileCommand.CreateExternalProfile request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentWithDependenciesAsync(request.studentId, cancellationToken); 

            if(student == null)
            {
                throw new Exception("Student not found");
            }

            student.AddExternalProfile(ExternalProfile.Create(request.studentId,  request.username, request.name, request.link));

            await _studentRepository.UpdateAsync(student, cancellationToken);

            return StudentDTO.From(student);
        }
    }
}