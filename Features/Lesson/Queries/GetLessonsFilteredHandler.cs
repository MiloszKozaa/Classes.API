using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Queries
{
    public class GetLessonsFilteredHandler : IRequestHandler<GetLessonsFiltered.GetLessonsFilteredQuery, List<LessonDTO>>
    {
        private readonly ILessonRepository _lessonRepository;
        public GetLessonsFilteredHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<List<LessonDTO>> Handle(GetLessonsFiltered.GetLessonsFilteredQuery request, CancellationToken cancellationToken)
        {
            if (request.start > request.end)
            {
                throw new Exception("Start date must be before end date");
            }
            
            return LessonDTO.From(await _lessonRepository.GetFilteredDateRangeAsync(request.start, request.end, cancellationToken));
        }
        
    }
}