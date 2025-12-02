using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes.Models
{
    public sealed class User : ModelBase
    {
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }

    private List<Student> Students { get; set; } = new List<Student>();
    private List<Lesson> Lessons { get; set; } = new List<Lesson>();
    private List<ExternalProfile> ExternalProfiles { get; set; } = new List<ExternalProfile>();
    }
}