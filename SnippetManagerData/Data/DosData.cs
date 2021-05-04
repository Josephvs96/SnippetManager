using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public class DosData : IOSdataAccess
    {

        private List<OSModel> os;

        public DosData()
        {
            os = new List<OSModel>();
            PopulateOS();
        }

        private void PopulateOS()
        {
            os.Add(new OSModel { id = 1, Name = "Windows", UserID = "1" });
            os.Add(new OSModel { id = 2, Name = "Linux", UserID = "1" });
            os.Add(new OSModel { id = 3, Name = "Mac", UserID = "1" });
        }

        public Task AddOS(OSModel os)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOS(OSModel os)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OSModel>> GetAllOS()
        {
            return os.ToList();
        }

        public async Task<List<OSModel>> GetOSById(string id)
        {
            return os.ToList();
        }
    }
}
