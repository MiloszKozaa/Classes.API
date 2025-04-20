using System.ComponentModel.DataAnnotations.Schema;

namespace Classes.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}