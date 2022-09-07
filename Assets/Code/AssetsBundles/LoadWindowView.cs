using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


namespace Mobile2D
{
    internal class LoadWindowView : AssetBundleViewBase
    {
        [SerializeField] private AssetReference _loadPrefab;
        [SerializeField] private RectTransform _mountSpawnTransform;
        [SerializeField] private Button _spawnAssetsButton;
        [SerializeField] private Button _loadAsssetsButton;
        
        private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new ();

        private void Start()
        {
            _loadAsssetsButton.onClick.AddListener(LoadAsset);
            _spawnAssetsButton.onClick.AddListener(CreateAddressablesPrefab);
        }

        private void OnDestroy()
        {
            _loadAsssetsButton.onClick.RemoveAllListeners();
            
            foreach (var addressablePrefab in _addressablePrefabs)
                Addressables.ReleaseInstance(addressablePrefab);
            
            _addressablePrefabs.Clear();
        }
        
        private void CreateAddressablesPrefab()
        {
            var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab, _mountSpawnTransform);
            _addressablePrefabs.Add(addressablePrefab);
        }
        
        private void LoadAsset()
        {
            _loadAsssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundle());
        }

    }
}