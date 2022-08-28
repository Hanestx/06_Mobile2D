using System.Linq;
using Mobile2D.AI;
using Mobile2D.Reward;
using UnityEngine;

  
namespace Mobile2D
{
    internal class Root : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private UnityAdsTools _unityAdsTools;
        [SerializeField] private ItemConfig[] _itemConfigs;
        [SerializeField] private DailyRewardView _dailyRewardView;
        [SerializeField] private CurrencyView _currencyView;
        [SerializeField] private FightWindowView _fightWindowView;
        [SerializeField] private StartFightView _startFightView;

        private ProfilePlayer _profilePlayer;
        private MainController _mainController;
        private float _speedCar = 15f;

        private void Start()
        {
            _profilePlayer = new ProfilePlayer(_speedCar, _unityAdsTools);
            _profilePlayer.CurrentState.Value = GameState.Start;
            _mainController = new MainController(_placeForUi,_itemConfigs.ToList(), 
                _profilePlayer,  _dailyRewardView, _currencyView, _fightWindowView, _startFightView);
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