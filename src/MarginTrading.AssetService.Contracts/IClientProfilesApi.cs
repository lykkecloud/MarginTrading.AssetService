﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MarginTrading.AssetService.Contracts.ClientProfiles;
using MarginTrading.AssetService.Contracts.Common;
using MarginTrading.AssetService.Contracts.ErrorCodes;
using Refit;

namespace MarginTrading.AssetService.Contracts
{
    public interface IClientProfilesApi
    {
        /// <summary>
        /// Get client profile by id
        /// </summary>
        /// <returns></returns>
        [Get("/api/client-profiles/{id}")]
        Task<GetClientProfileByIdResponse> GetClientProfileByIdAsync(Guid id);

        /// <summary>
        /// Get all client profiles
        /// </summary>
        /// <returns></returns>
        [Get("/api/client-profiles")]
        Task<GetAllClientProfilesResponse> GetClientProfilesAsync();

        /// <summary>
        /// Adds new broker regulatory profile to the system
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Post("/api/client-profiles")]
        Task<ErrorCodeResponse<ClientProfilesErrorCodesContract>> AddClientProfileAsync(
            [Body] AddClientProfileRequest request);

        /// <summary>
        /// Updates existing client profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Put("/api/client-profiles/{id}")]
        Task<ErrorCodeResponse<ClientProfilesErrorCodesContract>> UpdateClientProfileAsync(Guid id, [Body] UpdateClientProfileRequest request);

        /// <summary>
        /// Delete a client profile
        /// </summary>
        /// <returns></returns>
        [Delete("/api/client-profiles/{id}")]
        Task<ErrorCodeResponse<ClientProfilesErrorCodesContract>> DeleteClientProfileAsync(Guid id, [Query] string username);
    }
}