using UnityEngine;

namespace Mobile2D
{
    internal class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private UnityAdsTools _unityAdsTools;
        
        private ProfilePlayer _profilePlayer;
        private MainController _mainController;
        private float _speedCar = 15f;

        private void Start()
        {
            _profilePlayer = new ProfilePlayer(_speedCar, _unityAdsTools);
            _profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, _profilePlayer);
        }

        private void Update()
        {
            if (_profilePlayer.CurrentState.Value == GameState.Start)
                _mainController.Execute();
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}