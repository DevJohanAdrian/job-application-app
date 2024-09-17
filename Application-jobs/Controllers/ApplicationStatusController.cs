
using Microsoft.AspNetCore.Mvc;
using Application_jobs.DTOs;
using Application_jobs.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Application_jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {

        private readonly ApplicationStatusService _applicationStatusService;
        public ApplicationStatusController(ApplicationStatusService applicationStatusService)
        {
            _applicationStatusService = applicationStatusService;
        }

        [HttpGet]
        [Route("GetApplicationStatus")]
        public async Task<ActionResult<List<ApplicationStatusDTO>>> GetApplicationStatus()
        {
            var Status = await _applicationStatusService.GetApplicationStatus();

            return Ok(Status);
        }
    }
}
