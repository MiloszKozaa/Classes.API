using System.ComponentModel.DataAnnotations.Schema;

namespace Classes.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastEditedAt { get; set; }
        public Guid UserId { get; set; }

    }
}