namespace Lykke.MarginTrading.AssetService.Contracts.ErrorCodes
{
    public enum ProductsErrorCodesContract
    {
        None,
        AlreadyExists,
        DoesNotExist,
        UnderlyingDoesNotExist,
        CannotCreateCategory,
        CannotCreateProductInNonLeafCategory,
        MarketSettingsDoNotExist,
        CurrencyDoesNotExist,
        CanOnlyCreateOneProductPerUnderlying,
        TickFormulaDoesNotExist,
        AssetTypeDoesNotExist,
    }
}