using UnityEngine;


namespace Mobile2D
{
    internal class StartFightController : BaseController
    {
        private StartFightView _startFightViewInstance;
        private ProfilePlayer _profilePlayer;

        public StartFightController(Transform placeForUi, StartFightView startFightView, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _startFightViewInstance = Object.Instantiate(startFightView, placeForUi);
            AddGameObjects(_startFightViewInstance.gameObject);
        }

        public void RefreshView()
        {
            _startFightViewInstance.StartFightButton.onClick.AddListener(StartFight);
        }

        private void StartFight()
        {
            _profilePlayer.CurrentState.Value = GameState.Fight;
        }

        protected override void OnDispose()
        {
            _startFightViewInstance.StartFightButton.onClick.RemoveAllListeners();
            base.OnDispose();
        }
    }
}