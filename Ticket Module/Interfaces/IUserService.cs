using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;
using DataModelsforModule;
using ModuleDTOs;

namespace ModuleInterfaces
{
    public interface IUserService
    {
        Task<UserEntity> CreateUserAsync(UserEntity user);
        Task<List<UserEntity>> GetAllUsersAsync();
    }

}
