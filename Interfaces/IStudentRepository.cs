using Classes.Models;

namespace Classes.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Task<Student> UpdateAsync(Student student, CancellationToken cancellationToken = default);
        public Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);
        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);
        public Task<Student> GetStudentWithDependenciesAsync(Guid id, CancellationToken cancellationToken = default); 
    }
}