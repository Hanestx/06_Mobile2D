using System;
using UnityEngine;

namespace Mobile2D
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
        private ProfilePlayer profilePlayer;
        private float _speedCar = 15f;
        private MainController _mainController;

        private void Awake()
        {
            profilePlayer = new ProfilePlayer(_speedCar);
            profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi, profilePlayer);
        }

        private void Update()
        {
            if (profilePlayer.CurrentState.Value == GameState.Start)
                _mainController.Execute();
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}