﻿using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MarginTrading.SettingsService.Contracts.Routes;
using Refit;

namespace MarginTrading.SettingsService.Contracts
{
    [PublicAPI]
    public interface ITradingRoutesApi
    {
        [Get("/api/routes/")]
        Task<List<MatchingEngineRouteContract>> List();


        [Post("/api/routes/")]
        Task<MatchingEngineRouteContract> Insert([Body] MatchingEngineRouteContract route);


        [ItemCanBeNull]
        [Get("/api/routes/{routeId}")]
        Task<MatchingEngineRouteContract> Get([NotNull] string routeId);


        [Put("/api/routes/{routeId}")]
        Task<MatchingEngineRouteContract> Update( [NotNull] string routeId, [Body] MatchingEngineRouteContract route);


        [Delete("/api/routes/{routeId}")]
        Task Delete([NotNull] string routeId);
    }
}
