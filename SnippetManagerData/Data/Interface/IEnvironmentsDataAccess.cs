using SnippetManagerData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public interface IEnvironmentsDataAccess
    {
        Task AddEnvironment(EnvironmentModel environment);
        Task DeleteEnvironments(EnvironmentModel environment);
        Task<List<EnvironmentModel>> GetAllEnvironmetns();
        Task<List<EnvironmentModel>> GetEnvironmetnsById(string id);
    }
}