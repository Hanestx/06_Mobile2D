using UnityEngine.Advertisements;

namespace Mobile2D
{
    internal class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        
        public IAnalyticTools AnalyticTools { get; }
        public IAdsShower AdsShower{ get; }
        public IUnityAdsListener AdsListener { get;}
        public IShop ShopTools { get; }
        
        public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = new UnityAnalyticTools();
            AdsShower = unityAdsTools;
            AdsListener = unityAdsTools;
            ShopTools = new ShopProduct();
        }
    }
}