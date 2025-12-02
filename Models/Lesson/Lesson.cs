
using System.ComponentModel.DataAnnotations.Schema;

namespace Classes.Models
{
    public sealed class Lesson : ModelBase
    {
        public string Description { get; set; } = string.Empty;
        public LessonStatusEnum Status { get; set; } = LessonStatusEnum.Scheduled;
        public LessonTypeEnum Type { get; set; } = LessonTypeEnum.Remote;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Price { get; set; }
        public Guid StudentId { get; set; }

        private Lesson(Guid id, string description, LessonStatusEnum status, LessonTypeEnum type, DateTime start, DateTime end, float price, Guid studentId, DateTime createdAt, Guid userId, DateTime lastEditedAt)
        {
            Id = id;
            Description = description;
            Status = status;
            Type = type;
            Start = start;
            End = end;
            Price = price;
            StudentId = studentId;

            CreatedAt = createdAt;
            UserId = userId;
            LastEditedAt = lastEditedAt;
        }

        public static Lesson Create(Guid studentId, string description, LessonStatusEnum status, LessonTypeEnum type, DateTime start, DateTime end, float price, Guid userId)
        {
            return new Lesson(new Guid(), description, status, type, start, end, price, studentId, DateTime.UtcNow,userId, DateTime.UtcNow);
        }

        public Lesson Update(Guid studentId, string description, LessonStatusEnum status, LessonTypeEnum type, DateTime start, DateTime end, float price)
        {
            StudentId = studentId;
            Description = description;
            Status = status;
            Type = type;
            Start = start;
            End = end;
            Price = price;
            LastEditedAt = DateTime.UtcNow;

            return this;
        }
    }
}