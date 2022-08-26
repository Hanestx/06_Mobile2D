using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Mobile2D.Reward
{
    internal class DailyRewardController : BaseController
    {
        private readonly DailyRewardView _dailyRewardView;
        private List<ContainerSlotRewardView> _slots = new();
        private bool _isGetReward;

        public DailyRewardController(DailyRewardView dailyRewardView)
        {
            _dailyRewardView = dailyRewardView;
        }

        public void RefreshView()
        {
            InitSlots();
            _dailyRewardView.StartCoroutine(RewardsStateUpdater());
            RefreshUI();
            SubscribeButtons();
        }

        private void RefreshUI()
        {
            _dailyRewardView.GetRewardButton.interactable = _isGetReward;

            if (_isGetReward)
            {
                _dailyRewardView.TimerNewReward.text = "Get Reward!!!";
            }
            else
            {
                if (_dailyRewardView.TimeGetReward != null)
                {
                    var nextClaimTime = _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCooldown);
                    var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                    var timeGetReward = $"{currentClaimCooldown.Hours:D2} : {currentClaimCooldown.Minutes:D2} : {currentClaimCooldown.Seconds:D2}";
                    _dailyRewardView.TimerNewReward.text = $"Next reward: {timeGetReward}";
                }
            }
            
            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].SetData(_dailyRewardView.Rewards[i], i + 1, i == _dailyRewardView.CurrentSlotInActive);
            }
        }

        private void SubscribeButtons()
        {
            _dailyRewardView.GetRewardButton.onClick.AddListener(GetReward);
            _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
        }

        private void ResetTimer()
        {
            PlayerPrefs.DeleteAll();
        }

        private void GetReward()
        {
            if (!_isGetReward)
                return;

            var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.Stone:
                    CurrencyView.Instance.AddStone(reward.CountCurrency);
                    break;
                case RewardType.Diamond:
                    CurrencyView.Instance.AddDiamond(reward.CountCurrency);
                    break;
            }
            
            _dailyRewardView.TimeGetReward = DateTime.UtcNow;
            _dailyRewardView.CurrentSlotInActive =
                (_dailyRewardView.CurrentSlotInActive + 1) % _dailyRewardView.Rewards.Count;
            
            RefreshRewardState();
        }

        private IEnumerator RewardsStateUpdater()
        {
            while (true)
            {
                RefreshRewardState();
                yield return new WaitForSeconds(1);
            }
        }

        private void RefreshRewardState()
        {
            _isGetReward = true;

            if (_dailyRewardView.TimeGetReward.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;

                if (timeSpan.Seconds > _dailyRewardView.TimeDeadline)
                {
                    _dailyRewardView.TimeGetReward = null;
                    _dailyRewardView.CurrentSlotInActive = 0;
                }
                else if (timeSpan.Seconds < _dailyRewardView.TimeCooldown)
                {
                    _isGetReward = false;
                }
            }
            RefreshUI();
        }

        private void InitSlots()
        {
            for (int i = 0; i < _dailyRewardView.Rewards.Count; i++)
            {
                var instanceSlot = GameObject.Instantiate(_dailyRewardView.SlotRewardView, 
                    _dailyRewardView.MountRootSlotsReward, false);
                
                _slots.Add(instanceSlot);
            }
        }
    }
}