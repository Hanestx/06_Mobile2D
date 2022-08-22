using UnityEngine;
using UnityEngine.Advertisements;


namespace Mobile2D
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private string _gameId = "4888213";
        private string _bannerPlacementId = "Banner_Android";
        private string _rewardPlace = "rewardAds";
        private string _interstitialPlace = "Interstitial_Android";

        private void Awake()
        {
            Advertisement.Initialize(_gameId, true);
        }

        public void ShowInterstitial()
        {
            Advertisement.Show(_interstitialPlace);
        }

        public void ShowVideo()
        {
            Advertisement.Show(_rewardPlace);
        }

        public void ShowBanner()
        {
            Advertisement.Show(_bannerPlacementId);
        }

        public void OnUnityAdsDidError(string message)
        {
        }

        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Skipped)
            {
                Debug.Log("Skipped");
            }
        }
    }
}