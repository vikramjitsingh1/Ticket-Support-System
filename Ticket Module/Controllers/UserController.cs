using TicketModuleInfrastructure;
using ModuleInterfaces;
using ModuleServices;
using DataModelsforModule;
using ModuleDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace UserController
{

    /// <summary>
    /// Manage users
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Create a new user
        /// </summary>
        // Create a user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest request)
        {
            var user = new UserEntity
            {
                Username = request.Username
            };

            var createdUser = await _userService.CreateUserAsync(user);
            return (Ok(createdUser));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        // Get all users
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
