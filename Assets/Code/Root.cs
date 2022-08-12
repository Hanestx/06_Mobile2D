using UnityEngine;

namespace Mobile2D
{
    internal class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
        private ProfilePlayer _profilePlayer;
        private float _speedCar = 15f;
        private MainController _mainController;

        private void Awake()
        {
            _profilePlayer = new ProfilePlayer(_speedCar);
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