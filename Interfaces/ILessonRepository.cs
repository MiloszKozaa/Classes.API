using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Models;

namespace Classes.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        public Task<List<Lesson>> GetFilteredDateRangeAsync(DateTime? start, DateTime? end, CancellationToken cancellationToken = default);
        public Task<List<Lesson>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);
        public Task<Lesson> UpdateAsync(Lesson lesson, CancellationToken cancellationToken = default);
        // public Task<bool> LessonConflictsAsync(Guid lessonId, DateTime start, DateTime end, CancellationToken cancellationToken = default);

    }
}