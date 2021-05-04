using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public class DDataAccess : ISnippetDataAccess
    {
        private List<SnippetModel> snippets;

        public DDataAccess()
        {
            snippets = new List<SnippetModel>();
            PopulateList();
        }

        private void PopulateList()
        {
            SnippetModel snippet = new SnippetModel();
            snippet.id = 1;
            snippet.Name = "Insall Angular";
            snippet.Code = "npm install -g angular-cli";
            snippet.Environment = new EnvironmentModel { id = 2, Name = "Console" };
            snippet.OperatingSystem = new OSModel { id = 1, Name = "Windows" };
            snippet.UserID = "1";
            snippets.Add(snippet);

            snippet = new SnippetModel();
            snippet.id = 2;
            snippet.Name = "Insall Entity framework in vs-code";
            snippet.Code = "dotnet add package Microsoft.EntityFrameworkCore.SqlServer";
            snippet.Environment = new EnvironmentModel { id = 1, Name = "VS Code" };
            snippet.OperatingSystem = new OSModel { id = 2, Name = "Linux" };
            snippet.UserID = "1";
            snippets.Add(snippet);
        }

        public Task AddSnippet(SnippetModel snippet)
        {
            if (snippets.Count == 0)
            {
                snippet.id = 1;
            }
            else
            {
                snippet.id = snippets[snippets.Count - 1].id + 1;
            }
            snippets.Add(snippet);
            return Task.CompletedTask;
        }

        public Task DeleteSnippet(SnippetModel snippet)
        {
            snippets.Remove(snippet);
            return Task.CompletedTask;
        }

        public Task<List<SnippetModel>> GetAllSnippets()
        {
            return Task.FromResult(snippets.ToList());
        }

        public Task<List<string>> GetOSinSnippetsById(string id)
        {
            return Task.FromResult(snippets.Where(snippet => snippet.UserID == "1")
                                             .Select(x => x.OperatingSystem.Name)
                                             .ToList());
        }

        public Task<List<SnippetModel>> GetSnippetsById(string id)
        {
            return Task.FromResult(snippets.Where(x => x.UserID == "1").ToList());
        }

        public Task UpdateSnippet(SnippetModel snippet)
        {
            snippets.RemoveAll(x => x.id == snippet.id);
            snippets.Add(snippet);
            return Task.CompletedTask;
        }
    }
}
