using Microsoft.EntityFrameworkCore;


namespace SAPConnection.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }


        public DbSet<ApproversModel> Approvers { get; set; }
        public DbSet<WorkflowItem> Workflows { get; set; }

        public DbSet<StaticApproversModel> StaticApproversModels { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ShiftInchargeModel> ShiftIncharge { get; set; }





    }
}
