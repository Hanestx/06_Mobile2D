using UnityEngine;

namespace Mobile2D
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
       
        private float _speedCar = 15f;
        private MainController _mainController;

        private void Awake()
        {
            ProfilePlayer profilePlayer = new ProfilePlayer(_speedCar);
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer);
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}