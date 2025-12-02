using System;
using System.Threading;
using System.Threading.Tasks;
using Classes.Data;
using MediatR;

namespace Classes.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public ChangePasswordCommandHandler(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);
            
            if (user == null || !AuthHelpers.VerifyPassword(request.CurrentPassword, user.PasswordHash, _configuration))
                return false;

            user.PasswordHash = AuthHelpers.HashPassword(request.NewPassword, _configuration);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}