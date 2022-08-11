using System;
using UnityEngine;

namespace Mobile2D
{
    internal class MainController : BaseController
    {
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuController _mainMenuController;
        private GameController _gameController;

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        protected override void OnDispose()
        {
            AllDispose();
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController();
                    _mainMenuController?.Dispose();
                    break;
                default:
                    AllDispose();
                    break;
            }
        }
        
        private void AllDispose()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
        }
    }
}