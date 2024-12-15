﻿using UniverseApp.Core.Models.Starship;

namespace UniverseApp.Core.Services.Contracts
{
	public interface IStarshipService
	{
		Task<int> AddStarshipAsync(StarshipFormModel model);
        Task DeleteStarshipAsync(int id);
        Task EditStarshipAsync(int id, StarshipFormModel model);
		Task<bool> ExistByIdAsync(int id);

		Task<StarshipQueryServiceModel> GetAllStarshipsAsync(string? searchCharacter, string? searchMovie, int currentPage, int starshipsPerPage);
        Task<StarshipDeleteViewModel> GetStarshipDeleteModelByIdAsync(int id);
        Task<StarshipDetailsViewModel> GetStarshipDetailsByIdAsync(int id);
		Task<StarshipFormModel> GetStarshipFormByIdAsync(int id);
	}
}
