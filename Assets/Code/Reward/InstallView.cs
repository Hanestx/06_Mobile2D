using System;
using UnityEngine;

namespace Mobile2D.Reward
{
    internal class InstallView : MonoBehaviour
    {
        [SerializeField] private DailyRewardView _dailyRewardView;

        private DailyRewardController _dailyRewardController;

        private void Awake()
        {
            _dailyRewardController = new DailyRewardController(_dailyRewardView);
        }

        private void Start()
        {
            _dailyRewardController.RefreshView();
        }
    }
}