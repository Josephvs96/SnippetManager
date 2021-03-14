using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SnippetManagerData.Data;
using SnippetManagerData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetManager.Helpers
{
    public class StatisticsService
    {
        private readonly IOSdataAccess _osDb;
        private readonly ISnippetDataAccess _snippetDb;
        private readonly UserManager<IdentityUser> _user;
        private readonly AuthenticationStateProvider _context;

        public StatisticsService(IOSdataAccess os, ISnippetDataAccess snippet, UserManager<IdentityUser> user, AuthenticationStateProvider context)
        {
            _osDb = os;
            _snippetDb = snippet;
            _user = user;
            _context = context;
        }

        private string[] osNames;

        public Dictionary<string, double> includedOS { get; set; }

        public void PopulateData()
        {
            includedOS = new Dictionary<string, double>();
            GetOsNames();

            var user = _context.GetAuthenticationStateAsync().Result.User;
            var snippets = _snippetDb.GetOSinSnippetsById(_user.GetUserId(user)).Result;
            if (snippets is not null)
            {
                foreach (var os in snippets)
                {
                    if (includedOS.ContainsKey(os))
                    {
                        includedOS[os]++;
                    }
                    else
                        includedOS.Add(os, 1);
                }
            }
            foreach (var os in osNames)
            {
                if (!includedOS.ContainsKey(os))
                {
                    includedOS.Add(os, 0);
                }
            }
        }

        private void GetOsNames()
        {
            var user = _context.GetAuthenticationStateAsync().Result.User;
            List<OSModel> operatingSystems = _osDb.GetOSById(_user.GetUserId(user)).Result;
            if (operatingSystems is not null || operatingSystems.Count != 0)
            {
                List<string> osInList = new List<string>();
                foreach (var os in operatingSystems)
                {
                    osInList.Add(os.Name);
                }
                osNames = new string[operatingSystems.Count];
                osNames = osInList.ToArray();
            }
        }
    }
}
