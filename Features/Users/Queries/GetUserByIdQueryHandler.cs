using Classes.Data;
using Classes.Dtos;
using Classes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Classes.Features.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly DataContext _context;

        public GetUserByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(u => u.Id == request.UserId)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new Exception("User not found");

            return user;
        }
    }
}