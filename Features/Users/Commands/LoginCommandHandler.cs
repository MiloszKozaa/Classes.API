using System;
using System.Threading;
using System.Threading.Tasks;
using Classes.Data;
using Classes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Classes.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            if (user == null || !AuthHelpers.VerifyPassword(request.Password, user.PasswordHash, _configuration))
                throw new Exception("Invalid credentials");

            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            return AuthHelpers.GenerateJwtToken(user, _configuration);
        }
    }
}