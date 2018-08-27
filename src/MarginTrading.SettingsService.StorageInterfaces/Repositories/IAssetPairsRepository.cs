﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MarginTrading.SettingsService.Core.Domain;
using MarginTrading.SettingsService.Core.Interfaces;

namespace MarginTrading.SettingsService.StorageInterfaces.Repositories
{
    public interface IAssetPairsRepository
    {
        Task<IReadOnlyList<IAssetPair>> GetAsync(params string[] assetPairIds);
        Task<IAssetPair> GetAsync(string assetPairId);
        Task<IAssetPair> GetByBaseAssetPairAsync(string baseAssetPairId);
        Task<IAssetPair> GetByBaseAssetPairAndNotByIdAsync(string id, string baseAssetPairId);
        Task<IReadOnlyList<IAssetPair>> GetByLeAndMeModeAsync(string legalEntity = null, 
            string matchingEngineMode = null);
        Task<PaginatedResponse<IAssetPair>> GetByLeAndMeModeByPagesAsync(string legalEntity = null, 
            string matchingEngineMode = null, int? skip = null, int? take = null);
        Task<IAssetPair> GetByBaseQuoteAndLegalEntityAsync(string baseAssetId, string quoteAssetId, string legalEntity);
        Task<bool> TryInsertAsync(IAssetPair convert);
        Task<bool> TryInsertBatchAsync(IReadOnlyList<IAssetPair> assetPairs);
        Task DeleteAsync(string assetPairId);
        Task UpdateAsync(IAssetPair obj);
        Task UpdateBatchAsync(IReadOnlyList<IAssetPair> assetPairs);
        Task<IAssetPair> ChangeSuspendFlag(string assetPairId, bool suspendFlag);
    }
}
