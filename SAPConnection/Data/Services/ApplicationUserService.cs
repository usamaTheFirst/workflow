using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SAPConnection.Data.Services
{


    public class ApplicationUserService
    {
        private readonly IDbContextFactory<MyDbContext> _contextFactory;

        public ApplicationUserService(IDbContextFactory<MyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateUser(ApplicationUser user)
        {
            using var context = _contextFactory.CreateDbContext();
            context.ApplicationUser.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> fetchUsers()
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.ApplicationUser.AsQueryable();


            // query = query.Where(x => x.Pno == pno).OrderByDescending(x => x.Pno);

            return await query.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.ApplicationUser.AsQueryable();


            ApplicationUser applicationUser = query.Where(x => x.Email == email).FirstOrDefault();
            return applicationUser;
        }

        public async Task<ApplicationUser> GetUser(string pno)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.ApplicationUser.AsQueryable();
            ApplicationUser applicationUser = query.Where(x => x.Pno == pno).FirstOrDefault();
            return applicationUser;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            using var context = _contextFactory.CreateDbContext();
            context.ApplicationUser.Update(user);
            await context.SaveChangesAsync();
        }


        public async Task<List<ApplicationUser>> GetAllUser()
        {
            using var context = _contextFactory.CreateDbContext();
            List<ApplicationUser> users = await context.ApplicationUser.ToListAsync();
            return users;
        }


    }

}
