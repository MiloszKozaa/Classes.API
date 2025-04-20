using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using MediatR;

namespace Classes.Features.Lesson.Queries
{
    public class GetLesson
    {
        public record GetLessonQuery(Guid Id) : IRequest<LessonDTO>;
    }
}