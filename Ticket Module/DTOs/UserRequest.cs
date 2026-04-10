using DataModelsforModule;
using ModuleInterfaces;
using ModuleServices;
using Microsoft.AspNetCore.Mvc;

namespace ModuleDTOs
{ 
    public class UserRequest
    {
        public required string Username { get; set; }

    }
}
