using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Commands
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand.CreateLessonn, LessonDTO>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IStudentRepository _studentRepository;
        public CreateLessonCommandHandler(ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
        }
        public async Task<LessonDTO> Handle(CreateLessonCommand.CreateLessonn request, CancellationToken cancellationToken)
        {

            if (request.start > request.end)
            {
                throw new Exception("Start date must be before end date");
            }

            var conflicts = await _lessonRepository.GetFilteredDateRangeAsync(request.start, request.end, cancellationToken);

            if(conflicts.Count > 0)
            {
                throw new Exception("Lesson conflicts with existing lessons");
            }

            var student = await _studentRepository.GetAsync(request.studentId, cancellationToken);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            var lesson = await _lessonRepository.AddAsync(Models.Lesson.Create(request.studentId, request.description, request.status, request.type, request.start, request.end, request.price), cancellationToken);

            return LessonDTO.From(lesson);
        }
    }
}