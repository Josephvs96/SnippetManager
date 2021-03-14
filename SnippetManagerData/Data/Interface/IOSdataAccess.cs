using SnippetManagerData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public interface IOSdataAccess
    {
        Task AddOS(OSModel os);
        Task DeleteOS(OSModel os);
        Task<List<OSModel>> GetAllOS();
        Task<List<OSModel>> GetOSById(string id);
    }
}