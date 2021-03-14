using Microsoft.EntityFrameworkCore;
using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public class OSdataAccess : IOSdataAccess
    {
        private readonly SnippetDbContext _db;

        public OSdataAccess(SnippetDbContext db)
        {
            _db = db;
        }

        public async Task AddOS(OSModel os)
        {
            await _db.OperatingSystems.AddAsync(os);
            await _db.SaveChangesAsync();
        }

        public async Task<List<OSModel>> GetAllOS()
        {
            return await _db.OperatingSystems.ToListAsync();
        }

        public async Task<List<OSModel>> GetOSById(string id)
        {
            return await _db.OperatingSystems.Where(os => os.UserID == id)
                                              .ToListAsync();
        }

        public async Task DeleteOS(OSModel os)
        {
            _db.OperatingSystems.Remove(os);
            await _db.SaveChangesAsync();
        }
    }
}
