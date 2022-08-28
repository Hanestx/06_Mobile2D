using System;
using UnityEngine;

namespace Mobile2D.Reward
{
    internal class InstallView : MonoBehaviour
    {
        [SerializeField] private DailyRewardView _dailyRewardView;
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private CurrencyView _currencyView;
        private DailyRewardController _dailyRewardController;

        private void Awake()
        {
            _dailyRewardController = new DailyRewardController(_placeForUi, _dailyRewardView, _currencyView);
        }

        private void Start()
        {
            _dailyRewardController.RefreshView();
        }
    }
}