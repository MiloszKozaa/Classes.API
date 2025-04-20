using Classes.Models;

namespace Classes.Interfaces
{
    public interface IExternalProfileRepository : IRepository<ExternalProfile>
    {
        public Task<List<ExternalProfile>> GetAllByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);
    }
}