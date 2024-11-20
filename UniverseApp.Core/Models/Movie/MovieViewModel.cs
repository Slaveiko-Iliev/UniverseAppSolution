using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data.Models;
using static UniverseApp.Infrastructure.Common.Constants.MovieConst;

namespace UniverseApp.Core.Models.Movie
{
    public class MovieViewModel : MovieFormModel
    {
        public int Id { get; set; }
    }
}
