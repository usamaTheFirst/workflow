using Microsoft.EntityFrameworkCore;

namespace SAPConnection.Data.Services
{


    public class ApproversService
    {
        private readonly IDbContextFactory<MyDbContext> _contextFactory;

        public ApproversService(IDbContextFactory<MyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateApprover(ApproversModel approver)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Approvers.Add(approver);
            await context.SaveChangesAsync();
        }


        public async Task<List<ApproversModel>> GetAllApprovers()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Approvers.ToList();

        }
    }
}
