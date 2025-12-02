using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Data;
using Classes.Interfaces;
using Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace Classes.Repository
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;


        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .AnyAsync(u => u.Username == username, cancellationToken);
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email, cancellationToken);
        }
        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
{
    _context.Set<User>().Update(user);
    await _context.SaveChangesAsync(cancellationToken);
}
    }   
}