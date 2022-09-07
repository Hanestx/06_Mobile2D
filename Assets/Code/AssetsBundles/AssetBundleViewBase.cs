using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


namespace Mobile2D
{
    internal class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites =
            "https://drive.google.com/uc?export=download&id=1j3E2OOv7-9pWiKebJG9QOYPZM6_8NYeu";
            
        private const string UrlAssetBundleAudio =
            "https://drive.google.com/uc?export=download&id=1BlPUpwg7VeE-Psd3yPITGftoUHpfi4MF";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;
        [SerializeField] private DataAudioBundle[] _dataAudioBundles;

        private AssetBundle _spritesAssetBundle;
        private AssetBundle _audioAssetBundle;

        protected IEnumerator DownloadAndSetAssetBundle()
        {
            yield return GetSpritesAssetBundle();
            yield return GetAudioAssetBundle();
            
            if (_spritesAssetBundle == null || _audioAssetBundle == null)
            {
                Debug.LogError($"AssetBundle {_audioAssetBundle} failed to load");
                yield break;
            }

            SetDownloadAssets();
            yield return null;
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);
            yield return request.SendWebRequest();
            
            while (!request.isDone)
                yield return null;
            
            StateRequest(request, ref _spritesAssetBundle);
        }

        private IEnumerator GetAudioAssetBundle()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);
            yield return request.SendWebRequest();
            
            while (!request.isDone)
                yield return null;
            
            StateRequest(request, ref _audioAssetBundle);
            yield return null;
        }

        private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete");
            }
            else
            {
                Debug.Log(request.error);
            }
        }

        private void SetDownloadAssets()
        {
            foreach (var data in _dataSpriteBundles)
                data.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);

            foreach (var data in _dataAudioBundles)
            {
                data.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
                data.AudioSource.Play();
            }
        }
    }
}