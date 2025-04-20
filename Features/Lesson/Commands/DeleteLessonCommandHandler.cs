using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Commands
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand.DeleteLesson>
    {
        private readonly ILessonRepository _lessonRepository;
        public DeleteLessonCommandHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task Handle(DeleteLessonCommand.DeleteLesson request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetAsync(request.Id, cancellationToken);

            if (lesson == null)
            {
                throw new Exception("Lesson not found");
            }

            await _lessonRepository.RemoveAsync(lesson, cancellationToken);
        }
    }
}