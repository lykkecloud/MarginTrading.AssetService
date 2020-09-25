﻿namespace MarginTrading.AssetService.Core.Caches
{
    public interface IUnderlyingsCache
    {
        public void Start();
        public UnderlyingsCacheModel GetByMdsCode(string mdsCode);
        public void AddOrUpdate(UnderlyingsCacheModel underlying);
        public void Remove(UnderlyingsCacheModel underlying);
    }
}