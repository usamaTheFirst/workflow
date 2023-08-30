using Microsoft.EntityFrameworkCore;

namespace SAPConnection.Data.Services
{


    public class StaticApproverService
    {
        private readonly IDbContextFactory<MyDbContext> _contextFactory;

        public StaticApproverService(IDbContextFactory<MyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateStaticApprover(StaticApproversModel approver)
        {
            using var context = _contextFactory.CreateDbContext();
            context.StaticApproversModels.Add(approver);
            await context.SaveChangesAsync();
        }

        public async Task<List<StaticApproversModel>> GetAllStaticApproverRolesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var query = await context.StaticApproversModels.ToListAsync();
            //var query = await context.Workflows.FromSqlRaw("Select * from Workflows").ToListAsync();
            return query;
        }

        public async Task<List<string>> GetRoleByRoleId(string? rid)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = await context.StaticApproversModels.Where(w => w.RoleId == rid).Select(w => w.Role).ToListAsync();
            return query;
        }

        public async Task<string> GetMaxRoleId()
        {
            using var context = _contextFactory.CreateDbContext();
            var maxRoleId = await context.StaticApproversModels.MaxAsync(x => x.RoleId);
            return maxRoleId;
        }
    }

}
