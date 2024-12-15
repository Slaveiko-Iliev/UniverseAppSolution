using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Models.Home;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;
using UniverseApp.Infrastructure.Data.Models;

namespace UniverseApp.Core.Services
{
	public class HomeService : IHomeService
	{
		private readonly IRepository _repository;

		public HomeService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<MovieHomeViewModel>> GetBriefMoviesInfoAsync() =>
			await _repository
				.AllReadOnly<Movie>()
				.Select(m => new MovieHomeViewModel
				{
					Title = m.Name,
					Description = m.Description,
					ImageUrl = m.ImageUrl
				})
			.ToListAsync();
	}
}
