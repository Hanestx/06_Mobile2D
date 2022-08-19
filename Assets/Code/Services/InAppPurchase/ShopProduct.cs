using UnityEngine.Purchasing;

namespace Mobile2D
{
    internal class ShopProduct : IShop
    {
        public string Id;
        public string cost = "15$";
        public ProductType CurrentProductType;

        public string GetCost(string productID) => cost;
        public void Buy(string id) {}
        public void RestorePurchase() {}

        public IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        public IReadOnlySubscriptionAction OnFailedPurchase { get; }
    }
}