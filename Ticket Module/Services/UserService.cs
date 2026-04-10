using Microsoft.EntityFrameworkCore;
using ModuleInterfaces;
using DataModelsforModule;

namespace ModuleServices
{
    // Dependency Injection for the User Repository
    public class UserService(IUserRepository userrepo) : IUserService
    {
        private readonly IUserRepository _userrepo = userrepo;

        // Methods of User Service Class
        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            return await _userrepo.CreateUserAsync(user);
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _userrepo.GetAllUsersAsync();
        }
    }
}

