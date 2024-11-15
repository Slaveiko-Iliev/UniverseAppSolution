using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Core.Models.Home;

namespace UniverseApp.Core.Services.Contracts
{
    public interface IHomeService
    {
        Task<List<MovieHomeViewModel>> GetBriefMoviesInfoAsync();
    }
}
