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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetLessonsFilteredHandler(ILessonRepository lessonRepository, IHttpContextAccessor httpContextAccessor)
        {
            _lessonRepository = lessonRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<LessonDTO>> Handle(GetLessonsFiltered.GetLessonsFilteredQuery request, CancellationToken cancellationToken)
        {

            if (request.start > request.end)
            {
                throw new Exception("Start date must be before end date");
            }

            var userId = AuthHelpers.GetUserIdWithQueryPriority(
                    request.userId,
                    _httpContextAccessor.HttpContext!
                );
                
            var lessons = await _lessonRepository.GetAllAsync(cancellationToken);
            
            return LessonDTO.From(lessons.Where(l => (request.start == null || request.start < l.Start) && (request.end == null || request.end > l.End)).Where(l => l.UserId == userId).ToList());
        }
        
    }
}