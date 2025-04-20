using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Models;

namespace Classes.Dtos
{
    public class StudentDTO
    {
        public Guid Id { get; private set; }
        public string? Username { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public List<ExternalProfileDTO> ExternalProfiles { get; set; } = [];

        public static StudentDTO From(Student student) => new StudentDTO
        {
            Id = student.Id,
            Username = student.Username,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
            ExternalProfiles = ExternalProfileDTO.From(student.ExternalProfiles),
        };
        public static List<StudentDTO> From(List<Student> students)
        {
            return students.Select(From).ToList();
        }
    }
}