using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Data;
using Classes.Interfaces;
using Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace Classes.Repository
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        private readonly DataContext _context;
        public LessonRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetFilteredDateRangeAsync(DateTime? start, DateTime? end, CancellationToken cancellationToken = default)
        {
            return await _context.Lessons.Where(l => (start == null || start < l.Start) && (end == null || end > l.End)).ToListAsync(cancellationToken);
        }

        public async Task<List<Lesson>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default)
        {
            return await _context.Lessons.Where(l => l.StudentId == studentId).ToListAsync(cancellationToken);
        }


        public async Task<Lesson> UpdateAsync(Lesson lesson, CancellationToken cancellationToken = default)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync(cancellationToken);

            return lesson;
        }
    }
}