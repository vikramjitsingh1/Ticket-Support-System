using DataModelsforModule;
using Microsoft.AspNetCore.Mvc;
using ModuleInterfaces;
using ModuleServices;
using System.ComponentModel.DataAnnotations;

namespace ModuleDTOs
{
    /// <summary>
    /// Update Status of an existing assignment
    /// </summary>
    public class StatusRequest
    {
        /// <summary>
        /// Allowed values: Active, InProgress, Completed
        /// </summary>
        public StatusType Status { get; set; }
    }
}
