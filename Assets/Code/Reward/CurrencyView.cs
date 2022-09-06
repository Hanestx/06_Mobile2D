using System;
using TMPro;
using UnityEngine;

namespace Mobile2D.Reward
{
    internal class CurrencyView : MonoBehaviour
    {
        private const string StoneKey = nameof(StoneKey);
        private const string DiamondKey = nameof(DiamondKey);
        
        public static CurrencyView Instance { get; private set; }

        [SerializeField] private TMP_Text _currentCountStone;
        [SerializeField] private TMP_Text _currentCountDiamond;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            RefreshText();
        }

        private void RefreshText()
        {
            _currentCountStone.text = PlayerPrefs.GetInt(StoneKey).ToString();
            _currentCountDiamond.text = PlayerPrefs.GetInt(DiamondKey).ToString();
        }

        public void AddStone(int value)
        {
            SaveNewCountInPlayerPrefs(StoneKey, value);
            RefreshText();
        }
        
        public void AddDiamond(int value)
        {
            SaveNewCountInPlayerPrefs(DiamondKey, value);
            RefreshText();
        }

        private void SaveNewCountInPlayerPrefs(string key, int value)
        {
            var currencyCount = PlayerPrefs.GetInt(key);
            var newCount = currencyCount + value;
            PlayerPrefs.SetInt(key, newCount);
        }
    }
}