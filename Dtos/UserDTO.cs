using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Models;

namespace Classes.Dtos
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

         public static UserDTO From(User student) => new UserDTO
        {
            Id = student.Id,
            Username = student.Username,
            Email = student.Email,
        };
        public static List<UserDTO> From(List<User> users)
        {
            return users.Select(From).ToList();
        }

    }
    
}