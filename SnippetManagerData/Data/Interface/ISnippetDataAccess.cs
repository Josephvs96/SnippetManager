using SnippetManagerData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public interface ISnippetDataAccess
    {
        Task AddSnippet(SnippetModel snippet);
        Task DeleteSnippet(SnippetModel snippet);
        Task<List<SnippetModel>> GetAllSnippets();
        Task<List<SnippetModel>> GetSnippetsById(string id);
    }
}