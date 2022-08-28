using System.Collections.Generic;
using Mobile2D.AI;
using Mobile2D.Reward;
using UnityEngine;


namespace Mobile2D
{
    internal class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private TouchTrailController _touchTrailController;
        private GameController _gameController;
        private InventoryController _inventoryController;
        private DailyRewardController _dailyRewardController;
        private FightWindowController _fightWindowController;
        private CurrencyController _currencyController;
        private StartFightController _startFightController;

        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly List<ItemConfig> _itemsConfig;
        private readonly DailyRewardView _dailyRewardView;
        private readonly CurrencyView _currencyView;
        private readonly FightWindowView _fightWindowView;
        private readonly StartFightView _startFightView;

        public MainController(Transform placeForUi, List<ItemConfig> itemsConfig, 
            ProfilePlayer profilePlayer, DailyRewardView dailyRewardView, 
            CurrencyView currencyView, FightWindowView fightWindowView, 
            StartFightView startFightView)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            _itemsConfig = itemsConfig;
            _dailyRewardView = dailyRewardView;
            _currencyView = currencyView;
            _fightWindowView = fightWindowView;
            _startFightView = startFightView;


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
                    _startFightController = new StartFightController(_placeForUi, _startFightView, _profilePlayer);
                    _startFightController.RefreshView();
                    _mainMenuController?.Dispose();
                    _touchTrailController?.Dispose();
                    _fightWindowController?.Dispose();
                    break;
                case GameState.DailyReward:
                    _dailyRewardController = new DailyRewardController(_placeForUi, _dailyRewardView, _currencyView);
                    _dailyRewardController.RefreshView();
                    break;
                case GameState.Fight:
                    _fightWindowController = new FightWindowController(_placeForUi, _fightWindowView, _profilePlayer); 
                    _fightWindowController.RefreshView();
                    _mainMenuController?.Dispose();
                    _startFightController?.Dispose();
                    _gameController?.Dispose();
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
            _fightWindowController?.Dispose();
            _dailyRewardController?.Dispose();
            _startFightController?.Dispose();
        }
    }
}