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
            snippet.Environment = new EnvironmentModel { id = 1, Name = "Console" };
            snippet.OperatingSystem = new OSModel { id = 1, Name = "Windows" };
            snippet.UserID = "1";
            snippets.Add(snippet);
        }

        public async Task AddSnippet(SnippetModel snippet)
        {
            snippet.id = new Random(snippets[snippets.Count - 1].id).Next(12);
            snippet.UserID = "1";
            snippets.Add(snippet);
        }

        public async Task DeleteSnippet(SnippetModel snippet)
        {
            snippets.Remove(snippet);
        }

        public async Task<List<SnippetModel>> GetAllSnippets()
        {
            return snippets.ToList();
        }

        public async Task<List<string>> GetOSinSnippetsById(string id)
        {
            return snippets.Where(snippet => snippet.UserID == "1")
                                             .Select(x => x.OperatingSystem.Name)
                                             .ToList();
        }

        public async Task<List<SnippetModel>> GetSnippetsById(string id)
        {
            return snippets.Where(x => x.UserID == "1").ToList();
        }

        public async Task UpdateSnippet(SnippetModel snippet)
        {
            snippets.RemoveAll(x => x.id == snippet.id);
            snippets.Add(snippet);
        }
    }
}
