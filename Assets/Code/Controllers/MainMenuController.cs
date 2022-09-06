using Mobile2D.Reward;
using UnityEngine;
using UnityEngine.Advertisements;


namespace Mobile2D
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/MainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, DailyRewardGame);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }
        
        private void DailyRewardGame()
        {
            _profilePlayer.CurrentState.Value = GameState.DailyReward;
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("Start_game", ("time_start", Time.realtimeSinceStartup));
            _profilePlayer.AdsShower.ShowVideo();
            Advertisement.AddListener(_profilePlayer.AdsListener);
        }
    }
}