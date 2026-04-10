using TicketModuleInfrastructure;
using DataModelsforModule;
using Microsoft.EntityFrameworkCore;

namespace ModuleInterfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> CreateUserAsync(UserEntity user);
        public Task<List<UserEntity>> GetAllUsersAsync();
    }

    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
