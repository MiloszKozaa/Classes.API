using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Dtos;
using Classes.Models;
using MediatR;

namespace Classes.Features.Lesson.Commands
{
    public class UpdateLessonCommand
    {
         public record UpdateLessonn(Guid id, string description, LessonStatusEnum status, LessonTypeEnum type, DateTime start, DateTime end, float price, Guid studentId) : IRequest<LessonDTO>;
    }
}