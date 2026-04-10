using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;
using DataModelsforModule;
using ModuleDTOs;

namespace ModuleInterfaces
{
    public interface IAssignmentService
    {
        Task<StatusResponse?> GetAssignmentByIdAsync(int id);
        Task<StatusResponse> CreateAssignmentAsync(AssignmentEntity assignment);
        Task<StatusResponse> UpdateStatusAsync(int id, StatusRequest request);
    }

}
