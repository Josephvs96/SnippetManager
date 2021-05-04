using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerData.Data
{
    public class DEnvData : IEnvironmentsDataAccess
    {
        private List<EnvironmentModel> env;

        public DEnvData()
        {
            env = new List<EnvironmentModel>();
            PopulateData();
        }

        private void PopulateData()
        {
            env.Add(new EnvironmentModel { id = 1, Name = "VS Code", UserID = "1" });
            env.Add(new EnvironmentModel { id = 2, Name = "Console", UserID = "1" });
            env.Add(new EnvironmentModel { id = 3, Name = "SQL", UserID = "1" });
        }

        public Task AddEnvironment(EnvironmentModel environment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEnvironments(EnvironmentModel environment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EnvironmentModel>> GetAllEnvironmetns()
        {
            await Task.Delay(500);
            return env.ToList();
        }

        public async Task<List<EnvironmentModel>> GetEnvironmetnsById(string id)
        {
            await Task.Delay(500);
            return env.ToList();
        }
    }
}
