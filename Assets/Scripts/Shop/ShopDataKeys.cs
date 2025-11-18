using Core;


namespace Shop
{
    /// <summary>
    /// Набор ключей DataBus, используемых доменом магазина.
    /// </summary>
    public static class ShopDataKeys
    {
        public static readonly DataBusKey<ShopBundle> SelectedBundle = new("Shop.SelectedBundle");
    }
}


