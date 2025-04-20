using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using Classes.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Classes.Features.Student.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand.UpdateStudent, StudentDTO>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
      
        public async Task<StudentDTO> Handle(UpdateStudentCommand.UpdateStudent request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAsync(request.id, cancellationToken); 

            if(student == null)
            {
                throw new Exception("Student not found");
            }

            student.Update(request.username, request.firstName, request.lastName, request.email, request.phoneNumber); 

            // if(_studentRepository.UsernameExistsAsync(request.username, cancellationToken).Result)
            // {
            //     throw new Exception("Username already exists");
            // }
            
            // if(_studentRepository.EmailExistsAsync(request.email, cancellationToken).Result)
            // {
            //     throw new Exception("Email already exists");
            // }

            await _studentRepository.UpdateAsync(student, cancellationToken);

            return StudentDTO.From(student);;

        }
    }
}