using Microsoft.EntityFrameworkCore;

namespace SAPConnection.Data.Services
{
    public class ShiftInchargeService
    {
        private readonly IDbContextFactory<MyDbContext> _contextFactory;

        public ShiftInchargeService(IDbContextFactory<MyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateShiftIncharge(ShiftInchargeModel shiftInchargeModel)
        {
            using var context = _contextFactory.CreateDbContext();
            context.ShiftIncharge.Add(shiftInchargeModel);
            await context.SaveChangesAsync();
        }

    }
}
