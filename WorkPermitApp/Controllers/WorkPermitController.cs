using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;
using WorkPermitApp.Services.IServices;

namespace WorkPermitApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPermitController : ControllerBase
    {
       
        private readonly IWorkPermitService _workPermit;
        public WorkPermitController(IWorkPermitService workPermit)
        {
            _workPermit = workPermit;
        }


        [HttpPost()]
        [Route("RegisterUser")]
        public async Task<ActionResult<ApiResponse<bool>>> RegisterUser([FromBody] RegisterUserDto model)
        {
            var response = await _workPermit.RegisterUser(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost()]
        [Route("RequestWorkPermit")]
        public async Task<ActionResult<ApiResponse<bool>>> RequestWorkPermit([FromBody] WorkPermitRequestDto model)
        {
            var response = await _workPermit.RequestWorkPermit(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet()]
        [Route("GetAllWorkPermit")]
        public async Task<ActionResult<ApiResponse<WorkPermitsResponse>>> GetAllWorkPermit()
        {
            var response = await _workPermit.GetAllWorkPermitsRequest();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet()]
        [Route("ApproveWorkPermit")]
        public async Task<ActionResult<ApiResponse<bool>>> ApproveWorkPermit(string workPermitId)
        {
            var response = await _workPermit.ApproveWorkPermit(workPermitId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost()]
        [Route("SiteChecking")]
        public async Task<ActionResult<ApiResponse<bool>>> SiteChecking([FromBody] SiteCheckerRequestDto model)
        {
            var response = await _workPermit.SiteChecking(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet()]
        [Route("VerifyWorkSite")]
        public async Task<ActionResult<ApiResponse<bool>>> VerifyWorkSite(string workPermitId)
        {
            var response = await _workPermit.VerifyWorkSite(workPermitId);
            return StatusCode(response.StatusCode, response);
        }










    }
}
