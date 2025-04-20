using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Classes.Features.Lesson.Commands
{
    public class DeleteLessonCommand
    {
        public record DeleteLesson(Guid Id) : IRequest;
    }
}