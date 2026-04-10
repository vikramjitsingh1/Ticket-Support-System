using ModuleInterfaces;
using Microsoft.EntityFrameworkCore;
using DataModelsforModule;
using ModuleDTOs;

namespace ModuleServices
{

    // Dependency Injection for the Assignment Repository
    public class AssignmentService(IAssignmentRepository assignrepo) : IAssignmentService
    {
        private readonly IAssignmentRepository _assignrepo = assignrepo;


        // Methods for the Assignment Service Class
        public async Task<StatusResponse?> GetAssignmentByIdAsync(int id)
        {
            var assignment = await _assignrepo.GetAssignmentByIdAsync(id);
            if (assignment == null) return null;
            return new StatusResponse
            {
                AssignmentId = assignment.Id,
                TicketId = assignment.TicketId,
                UserId = assignment.UserId,
                Status = assignment.Status
            };
        }

        public async Task<StatusResponse> CreateAssignmentAsync(AssignmentEntity assignment)
        {
            var createdAssignment = await _assignrepo.CreateAssignmentAsync(assignment);
            return new StatusResponse
            {
                AssignmentId = createdAssignment.Id,
                TicketId = createdAssignment.TicketId,
                UserId = createdAssignment.UserId,
                Status = createdAssignment.Status
            };
        }

        public async Task<StatusResponse> UpdateStatusAsync(int id, StatusRequest request)
        {
            var updatedAssignment = await _assignrepo.GetAssignmentByIdAsync(id);

            if (updatedAssignment == null)
            {
                throw new Exception($"Assignment with ID {id} not found.");
            }
            if (Enum.IsDefined(typeof(StatusType), request.Status) == false)
            {
                throw new ArgumentException("Status must be Active, InProgress, or Completed");
            }

            updatedAssignment.Status = request.Status;

            var updated = await _assignrepo.UpdateStatusAsync(updatedAssignment);

            return new StatusResponse
            {
                AssignmentId = updatedAssignment.Id,
                TicketId = updatedAssignment.TicketId,
                UserId = updatedAssignment.UserId,
                Status = updatedAssignment.Status
            };
        }
    }
}
