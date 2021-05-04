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
            await Task.Delay(500);
            snippet.id = new Random(snippets[snippets.Count - 1].id).Next(12);
            snippet.UserID = "1";
            snippets.Add(snippet);
        }

        public async Task DeleteSnippet(SnippetModel snippet)
        {
            await Task.Delay(500);
            snippets.Remove(snippet);
        }

        public async Task<List<SnippetModel>> GetAllSnippets()
        {
            await Task.Delay(500);
            return snippets.ToList();
        }

        public Task<List<string>> GetOSinSnippetsById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SnippetModel>> GetSnippetsById(string id)
        {
            await Task.Delay(500);
            return snippets.Where(x => x.UserID == "1").ToList();
        }

        public async Task UpdateSnippet(SnippetModel snippet)
        {
            await Task.Delay(500);
            snippets.RemoveAll(x => x.id == snippet.id);
            snippets.Add(snippet);
        }
    }
}
