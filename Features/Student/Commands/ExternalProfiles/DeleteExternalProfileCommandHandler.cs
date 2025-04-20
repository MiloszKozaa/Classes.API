using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Student.Commands.ExternalProfiles
{
    public class DeleteExternalProfileCommandHandler : IRequestHandler<DeleteExternalProfileCommand.DeleteExternalProfile, StudentDTO>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteExternalProfileCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDTO> Handle(DeleteExternalProfileCommand.DeleteExternalProfile request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentWithDependenciesAsync(request.Id, cancellationToken); 

            if(student == null)
            {
                throw new Exception("Student not found");
            }

            student.DeleteExternalProfile(request.ExternalProfileId);

            await _studentRepository.UpdateAsync(student, cancellationToken);

            return StudentDTO.From(student);
        }
    }
}