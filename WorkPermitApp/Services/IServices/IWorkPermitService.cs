using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;

namespace WorkPermitApp.Services.IServices
{
    public interface IWorkPermitService
    {
        Task<ApiResponse<bool>> RegisterUser(RegisterUserDto request);
        Task<ApiResponse<bool>> RequestWorkPermit(WorkPermitRequestDto request);
        Task<ApiResponse<List<WorkPermitsResponse>>> GetAllWorkPermitsRequest();
        Task<ApiResponse<bool>> ApproveWorkPermit(string workPermitId);
        Task<ApiResponse<bool>> VerifyWorkSite(string workPermitId);
        Task<ApiResponse<bool>> SiteChecking(SiteCheckerRequestDto request);
    }
}
