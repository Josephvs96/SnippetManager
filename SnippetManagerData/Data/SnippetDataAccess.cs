using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SnippetManagerData.Models;

namespace SnippetManagerData.Data
{
    public class SnippetDataAccess : ISnippetDataAccess
    {
        private readonly SnippetDbContext _db;

        public SnippetDataAccess(SnippetDbContext db)
        {
            _db = db;
        }

        public async Task<List<SnippetModel>> GetSnippetsById(string id)
        {
            return await _db.Snippets.Where(snippet => snippet.UserID == id)
                                             .Include(snippet => snippet.Environment)
                                             .ToListAsync();
        }

        public async Task<List<SnippetModel>> GetAllSnippets()
        {
            return await _db.Snippets.Include(snippet => snippet.Environment)
                                     .ToListAsync();
        }

        public async Task AddSnippet(SnippetModel snippet)
        {
            await _db.Snippets.AddAsync(snippet);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteSnippet(SnippetModel snippet)
        {
            _db.Snippets.Remove(snippet);
            await _db.SaveChangesAsync();
        }
    }
}
