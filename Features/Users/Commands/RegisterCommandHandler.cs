using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Data;
using Classes.Dtos;
using Classes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Classes.Features.Users.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDTO>
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public RegisterCommandHandler(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                throw new Exception("Username already exists");

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                throw new Exception("Email already exists");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = AuthHelpers.HashPassword(request.Password, _configuration), // Użyj AuthHelpers
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return UserDTO.From(user);
        }
    }
}