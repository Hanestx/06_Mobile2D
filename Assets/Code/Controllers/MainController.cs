using System.Collections.Generic;
using UnityEngine;


namespace Mobile2D
{
    internal class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private TouchTrailController _touchTrailController;
        private GameController _gameController;
        private InventoryController _inventoryController;

        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly List<ItemConfig> _itemsConfig;

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemsConfig)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            _itemsConfig = itemsConfig;

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
                    _touchTrailController = new TouchTrailController();
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _inventoryController = new InventoryController(_itemsConfig);
                    _inventoryController.ShowInventory();
                    _gameController = new GameController(_profilePlayer);
                    _mainMenuController?.Dispose();
                    _touchTrailController?.Dispose();
                    break;
                default:
                    AllDispose();
                    break;
            }
        }

        public void Execute()
        {
            _touchTrailController.Execute();
        }

        private void AllDispose()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
            _inventoryController?.Dispose();
        }
    }
}