using Microsoft.EntityFrameworkCore;
using SnippetManagerData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public class EnvironmentsDataAccess : IEnvironmentsDataAccess
    {
        private readonly SnippetDbContext _db;

        public EnvironmentsDataAccess(SnippetDbContext db)
        {
            _db = db;
        }

        public async Task AddEnvironment(EnvironmentModel environment)
        {
            await _db.Environments.AddAsync(environment);
            await _db.SaveChangesAsync();
        }

        public async Task<List<EnvironmentModel>> GetAllEnvironmetns()
        {
            return await _db.Environments.ToListAsync();
        }

        public async Task<List<EnvironmentModel>> GetEnvironmetnsById(string id)
        {
            return await _db.Environments.Where(env => env.UserID == id)
                                              .ToListAsync();
        }

        public async Task DeleteEnvironments(EnvironmentModel environment)
        {
            _db.Environments.Remove(environment);
            await _db.SaveChangesAsync();
        }
    }
}
