using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkPermitApp.Data;
using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;
using WorkPermitApp.Models;
using WorkPermitApp.Repository.Interfaces;

namespace WorkPermitApp.Repository.Implementation
{
    public class WorkPermitRepository : IWorkPermitRepository
    {
        private readonly WorkPermitDbContext _dbContext;
        private readonly ILogger<WorkPermitRepository> _logger;
        private readonly IMapper _mapper;
        public WorkPermitRepository(WorkPermitDbContext dbContext, ILogger<WorkPermitRepository> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;   
        }

        public async Task<bool> ApproveWorkPermit(string workPermitId)
        {
            var getWorkSite = await _dbContext.WorkPermits.SingleOrDefaultAsync(e => e.Id == workPermitId);
            if (getWorkSite != null)
            {
                getWorkSite.PermitStatus = PermitStatus.IsApproved;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<WorkPermitsResponse>> GetAllWorkPermitsRequest()
        {
            var getAllWorkPermits = await _dbContext.WorkPermits.ToListAsync();
            var workPermitsData = _mapper.Map<List<WorkPermitsResponse>>(getAllWorkPermits);
            return workPermitsData;
        }

        public async Task<bool> RegisterUser(RegisterUserDto request)
        {
            try
            {
                var createUser = new AppUser
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    Role = request.Role
                };
                await _dbContext.AppUsers.AddAsync(createUser);
                await _dbContext.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error due to: {ex.InnerException.Message}");
                return false;
            }
            return true;

        }

        public async Task<bool> RequestWorkPermit(WorkPermitRequestDto request)
        {
            try
            {
                var requestData = _mapper.Map<WorkPermit>(request);
                await _dbContext.WorkPermits.AddAsync(requestData); 
                await _dbContext.SaveChangesAsync();    
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error due to: {ex.InnerException.Message}");
                return false;
            }
            return true;
        }

        public async Task<bool> SiteChecking(SiteCheckerRequestDto request)
        {
            try
            {
                var requestData = _mapper.Map<SiteChecker>(request);
                await _dbContext.SiteCheckers.AddAsync(requestData);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error due to: {ex.InnerException.Message}");
                return false;
            }
            return true;
        }

        public async Task<bool> VerifyWorkSite(string workPermitId)
        {
            var getWorkSite = await _dbContext.WorkPermits.SingleOrDefaultAsync(e=>e.Id == workPermitId);
            if (getWorkSite != null)
            {
                getWorkSite.PermitStatus = PermitStatus.IsSiteChecked;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
