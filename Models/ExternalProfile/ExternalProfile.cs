
namespace Classes.Models
{
    public sealed class ExternalProfile : ModelBase
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        private ExternalProfile(Guid id, string username, string name, string link, Guid studentId, DateTime createdAt, Guid userId, DateTime lastEditedAt)
        {
            Id = id;
            Username = username;
            Name = name;
            Link = link;
            StudentId = studentId;
            CreatedAt = createdAt;
            userId = userId;
            LastEditedAt = lastEditedAt;
        }
        public static ExternalProfile Create(Guid studentId, string username, string name, string link, Guid userId)
        {
            return new ExternalProfile(new Guid(), username, name, link, studentId, DateTime.UtcNow,userId, DateTime.UtcNow);
        }
    }
}