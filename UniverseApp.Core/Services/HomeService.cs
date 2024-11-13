using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;

namespace UniverseApp.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository _repository;

        public HomeService(IRepository repository)
        {
            _repository = repository;
        }


    }
}
