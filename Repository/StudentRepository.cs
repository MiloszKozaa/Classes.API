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
    public sealed class StudentRepository : Repository<Student>, IStudentRepository
    {
        DataContext _context;
        public StudentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);

            return student;
        }

        public async Task<Student> GetStudentWithDependenciesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students
                .Include(x => x.ExternalProfiles)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return student;
        }

        public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Students.AnyAsync(x => x.Username == username, cancellationToken);
        }
        public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Students.AnyAsync(x => x.Email == email, cancellationToken);
        }
    }
}