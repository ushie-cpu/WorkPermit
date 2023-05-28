using AutoMapper;
using Azure.Core;
using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;
using WorkPermitApp.Repository.Interfaces;
using WorkPermitApp.Services.IServices;

namespace WorkPermitApp.Services.Implementation
{
    public class WorkPermitService: IWorkPermitService
    {
        private readonly IWorkPermitRepository _workPermit;
        private readonly IMapper _mapper;
        public WorkPermitService(IWorkPermitRepository workPermit, IMapper mapper) 
        { 
            _workPermit = workPermit;    
            _mapper = mapper; 
        }

        public async Task<ApiResponse<bool>> ApproveWorkPermit(string workPermitId)
        {
            var response = await _workPermit.ApproveWorkPermit(workPermitId);
            if (!response)
                return ApiResponse<bool>.Fail("Unable to Approve Work Permit", StatusCodes.Status400BadRequest);
            return ApiResponse<bool>.Success("Work Permit Approved Succesfully", response, StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<List<WorkPermitsResponse>>> GetAllWorkPermitsRequest()
        {
            var getAllPermits = await _workPermit.GetAllWorkPermitsRequest();
            var allPermitsData = _mapper.Map<List<WorkPermitsResponse>>(getAllPermits);
            return ApiResponse<List<WorkPermitsResponse>>.Success("Success", allPermitsData, StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<bool>> RegisterUser(RegisterUserDto request)
        {
            var response = await _workPermit.RegisterUser(request);
            if (!response)
                return ApiResponse<bool>.Fail("Failed to register user", StatusCodes.Status400BadRequest);
            return ApiResponse<bool>.Success("User Created Successfully", response, StatusCodes.Status201Created);
            
        }

        public async Task<ApiResponse<bool>> RequestWorkPermit(WorkPermitRequestDto request)
        {
            var response = await _workPermit.RequestWorkPermit(request);
            if(!response)
                return ApiResponse<bool>.Fail("Unable to request Work Permit", StatusCodes.Status400BadRequest);
            return ApiResponse<bool>.Success("Work Permit Requested Succesfully", response, StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<bool>> SiteChecking(SiteCheckerRequestDto request)
        {
            var response = await _workPermit.SiteChecking(request);
            if (!response)
                return ApiResponse<bool>.Fail("Unable to Submit Site Checking", StatusCodes.Status400BadRequest);
            return ApiResponse<bool>.Success("Site Checked Succesfully", response, StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<bool>> VerifyWorkSite(string workPermitId)
        {
            var response = await _workPermit.VerifyWorkSite(workPermitId);
            if (!response)
                return ApiResponse<bool>.Fail("Unable to Verify Work Permit", StatusCodes.Status400BadRequest);
            return ApiResponse<bool>.Success("Work Permit Verified Succesfully", response, StatusCodes.Status201Created);
        }
    }
}
