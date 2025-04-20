using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Interfaces;
using MediatR;

namespace Classes.Features.Lesson.Queries
{
    public class GetLessonsByStudentHandler : IRequestHandler<GetLessonsByStudent.GetLessonsByStudentQuery, List<LessonDTO>>
    {
        private readonly ILessonRepository _lessonRepository;
        public GetLessonsByStudentHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<List<LessonDTO>> Handle(GetLessonsByStudent.GetLessonsByStudentQuery request, CancellationToken cancellationToken)
        {
            return LessonDTO.From(await _lessonRepository.GetByStudentIdAsync(request.StudentId, cancellationToken));
        }
    }
}