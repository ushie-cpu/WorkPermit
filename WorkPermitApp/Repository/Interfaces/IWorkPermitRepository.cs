using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;

namespace WorkPermitApp.Repository.Interfaces
{
    public interface IWorkPermitRepository
    {
        Task<bool> RegisterUser(RegisterUserDto request);
        Task<bool> RequestWorkPermit(WorkPermitRequestDto request);
        Task<List<WorkPermitsResponse>> GetAllWorkPermitsRequest();
        Task<bool> ApproveWorkPermit(string workPermitId);
        Task<bool> VerifyWorkSite(string workPermitId);
        Task<bool> SiteChecking(SiteCheckerRequestDto request);

    }
}
