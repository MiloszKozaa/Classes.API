using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Models;

namespace Classes.Dtos
{
    public class LessonDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public LessonStatusEnum Status { get; set; } = LessonStatusEnum.Scheduled;
        public LessonTypeEnum Type { get; set; } = LessonTypeEnum.Remote;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Price { get; set; }
        public Guid StudentId { get; set; }

        public static LessonDTO From(Lesson lesson) => new LessonDTO
        {
            Id = lesson.Id,
            Description = lesson.Description,
            Status = lesson.Status,
            Type = lesson.Type,
            Start = lesson.Start,
            End = lesson.End,
            Price = lesson.Price,
            StudentId = lesson.StudentId
        };
        public static List<LessonDTO> From(List<Lesson> lessons)
        {
            return lessons.Select(From).ToList();
        }
    }
}