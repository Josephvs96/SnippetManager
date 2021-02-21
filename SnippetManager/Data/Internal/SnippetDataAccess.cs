using SnippetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SnippetManager.Data.Internal
{
    public class SnippetDataAccess
    {
        private readonly ApplicationDbContext _db;

        public List<SnippetModel> Snippets { get; set; }

        public SnippetDataAccess(ApplicationDbContext db)
        {
            Snippets = new List<SnippetModel>();
            _db = db;
        }

        public void GetSnippetsById(string id)
        {
            Snippets = (from snippet in _db.Snippets
                        where snippet.UserID == id
                        select snippet).ToList();
        }
    }
}
