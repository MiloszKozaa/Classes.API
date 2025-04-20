using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Student.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand.CreateStudent, StudentDTO>
    {

        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDTO> Handle(CreateStudentCommand.CreateStudent request, CancellationToken cancellationToken)
        {

            // if(_studentRepository.UsernameExistsAsync(request.username, cancellationToken).Result)
            // {
            //     throw new Exception("Username already exists");
            // }

            // if(_studentRepository.EmailExistsAsync(request.email, cancellationToken).Result)
            // {
            //     throw new Exception("Email already exists");
            // }

            var student = await _studentRepository.AddAsync(Models.Student.Create(request.username, request.firstName, request.lastName, request.phoneNumber, request.email), cancellationToken);

            return StudentDTO.From(student);
        }
    }

}