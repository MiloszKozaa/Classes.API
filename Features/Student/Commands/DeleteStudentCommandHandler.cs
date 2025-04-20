using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Student.Commands
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand.DeleteStudent>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Handle(DeleteStudentCommand.DeleteStudent request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAsync(request.Id, cancellationToken); 

            if(student == null)
            {
                throw new Exception("Student not found");
            }

            await _studentRepository.RemoveAsync(student, cancellationToken);
        }
    }
}