using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Lesson.Queries
{
    public class GetLessonsByStudent
    {
        public record GetLessonsByStudentQuery(Guid StudentId) : IRequest<List<LessonDTO>>;
    }
}