using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnippetManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SnippetModel> Snippets { get; set; }
        public DbSet<EnvironmentModel> Environments { get; set; }
    }
}
