using Microsoft.EntityFrameworkCore;
using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetManagerData.Data
{
    public class SnippetDbContext : DbContext
    {
        public SnippetDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<SnippetModel> Snippets { get; set; }
        public DbSet<EnvironmentModel> Environments { get; set; }
    }
}
