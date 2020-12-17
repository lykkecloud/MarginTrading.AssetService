﻿// Copyright (c) 2019 Lykke Corp.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using MarginTrading.AssetService.Core.Domain;

namespace MarginTrading.AssetService.Core.Interfaces
{
    public interface IScheduleSettings
    {
        string Id { get; }
        int Rank { get; }
        string AssetPairRegex { get; }
        HashSet<string> AssetPairs { get; }
        string MarketId { get; }
        string MarketName { get; }

        bool? IsTradeEnabled { get; }
        TimeSpan? PendingOrdersCutOff { get; }

        ScheduleConstraint Start { get; }
        ScheduleConstraint End { get; }
   }
}
