using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Commands
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand.UpdateLessonn, LessonDTO>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IStudentRepository _studentRepository;
        public UpdateLessonCommandHandler(ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
        }
        public async Task<LessonDTO> Handle(UpdateLessonCommand.UpdateLessonn request, CancellationToken cancellationToken)
        {
            if (request.start > request.end)
            {
                throw new Exception("Start date must be before end date");
            }

            var lesson = await _lessonRepository.GetAsync(request.id, cancellationToken);

            if (lesson == null)
            {
                throw new Exception("Lesson not found");
            }

            var conflicts = (await _lessonRepository.GetFilteredDateRangeAsync(request.start, request.end, cancellationToken)).Where(lesson => lesson.Id != request.id).ToList();

            if(conflicts.Count > 0)
            {
                throw new Exception("Lesson conflicts with existing lessons");
            }

            var student = await _studentRepository.GetAsync(request.studentId, cancellationToken);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            lesson.Update(request.studentId, request.description, request.status, request.type, request.start, request.end, request.price);

            await _lessonRepository.UpdateAsync(lesson, cancellationToken);

            return LessonDTO.From(lesson);
        }
    }
}


// {
//     "id": "01965499-be5b-7164-a373-0f751e3e3665",
//     "description": "test PATH",
//     "status": 1,
//     "type": 1,
//     "start": "2025-04-20T19:06:51.557Z",
//     "end": "2025-04-20T20:06:51.557Z",
//     "price": 50,
//     "studentId": "01964e5e-5519-78c3-86d4-73a5696ea987"
//   }