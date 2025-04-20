using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Queries
{
    public class GetLessonHandler : IRequestHandler<GetLesson.GetLessonQuery, LessonDTO>
    {
        private readonly ILessonRepository _lessonRepository;
        public GetLessonHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<LessonDTO> Handle(GetLesson.GetLessonQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetAsync(request.Id, cancellationToken);

            if (lesson == null)
            {
                throw new Exception("Lesson not found");
            }
            
            return LessonDTO.From(lesson);
        }
    }
}