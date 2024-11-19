﻿namespace UniverseApp.Core.Services.Contracts
{
    public interface IServiceHelper
    {
        string[] SplitInput(string input);
        Task<ICollection<T>> GetEntitiesByIds<T>(int[] ids) where T : class;
    }
}
