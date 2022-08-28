using Mobile2D.AI;
using UnityEngine;


namespace Mobile2D
{
    internal class FightWindowController : BaseController
    {
        private FightWindowView _fightWindowViewInstance;
        private ProfilePlayer _profilePlayer;
        private Money _money;
        private Health _health;
        private Power _power;
        private Criminal _criminal;
        private Enemy _enemy;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _allCountCriminalPlayer = 5;

        public FightWindowController(Transform placeForUi, FightWindowView fightWindowView, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _fightWindowViewInstance = GameObject.Instantiate(fightWindowView, placeForUi);
        }

        public void RefreshView()
        {
            _enemy = new Enemy("BadCar");

            _money = new Money();
            _money.Attach(_enemy);

            _health = new Health();
            _health.Attach(_enemy);

            _power = new Power();
            _power.Attach(_enemy);

            _criminal = new Criminal();
            _criminal.Attach(_enemy);
            CheckCriminalLevel();
            SubscribeButtons();
        }

        private void SubscribeButtons()
        {
            _fightWindowViewInstance.AddMoneyButton.onClick.AddListener(() => ChangeMoney(true));
            _fightWindowViewInstance.MinusMoneyButton.onClick.AddListener(() => ChangeMoney(false));
            _fightWindowViewInstance.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _fightWindowViewInstance.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
            _fightWindowViewInstance.AddPowerButton.onClick.AddListener(() => ChangePower(true));
            _fightWindowViewInstance.MinusPowerButton.onClick.AddListener(() => ChangePower(false));
            _fightWindowViewInstance.AddCriminalLevelButton.onClick.AddListener(() => ChangeCriminal(true));
            _fightWindowViewInstance.MinusCriminalLevelButton.onClick.AddListener(() => ChangeCriminal(false));
            _fightWindowViewInstance.FightButton.onClick.AddListener(Fight);
            _fightWindowViewInstance.LeaveFightButton.onClick.AddListener(CloseWindow);
            _fightWindowViewInstance.SkipButton.onClick.AddListener(SkipLevel);
        }

        private void SkipLevel()
        {
            Debug.Log("You skip level");
        }

        private void ChangeCriminal(bool isAddCount)
        {
            if (isAddCount)
                _allCountCriminalPlayer++;
            else
                _allCountCriminalPlayer--;

            ChangeDataWindow(_allCountCriminalPlayer, DataType.Criminal);
            CheckCriminalLevel();
        }

        private void CheckCriminalLevel()
        {
            if (_allCountCriminalPlayer < 0 || _allCountCriminalPlayer > 5)
                return;

            if (_allCountCriminalPlayer >= 3)
                _fightWindowViewInstance.SkipButton.interactable = false;
            else
                _fightWindowViewInstance.SkipButton.interactable = true;
        }

        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount)
                _allCountMoneyPlayer++;
            else
                _allCountMoneyPlayer--;

            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
        }

        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount)
                _allCountHealthPlayer++;
            else
                _allCountHealthPlayer--;

            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
        }

        private void ChangePower(bool isAddCount)
        {
            if (isAddCount)
                _allCountPowerPlayer++;
            else
                _allCountPowerPlayer--;

            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
        }

        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _fightWindowViewInstance.CountMoneyText.text = $"Player Money{countChangeData.ToString()}";
                    _money.CountMoney = countChangeData;
                    break;
                case DataType.Health:
                    _fightWindowViewInstance.CountHealthText.text = $"Player Health{countChangeData.ToString()}";
                    _health.CountHealth = countChangeData;
                    break;
                case DataType.Power:
                    _fightWindowViewInstance.CountPowerText.text = $"Player Force{countChangeData.ToString()}";
                    _power.CountPower = countChangeData;
                    break;
                case DataType.Criminal:
                    _fightWindowViewInstance.CountCriminalText.text =
                        $"Player criminal level: {countChangeData.ToString()}";
                    _criminal.CriminalLevel = countChangeData;
                    break;
            }

            _fightWindowViewInstance.CountPowerEnemyText.text = $"Enemy Force{_enemy.Power}";
        }

        private void CloseWindow()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }

        protected override void OnDispose()
        {
            _fightWindowViewInstance.AddMoneyButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.MinusMoneyButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.AddHealthButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.MinusHealthButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.AddPowerButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.MinusPowerButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.AddCriminalLevelButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.MinusCriminalLevelButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.FightButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.LeaveFightButton.onClick.RemoveAllListeners();
            _fightWindowViewInstance.SkipButton.onClick.RemoveAllListeners();

            _money.Detach(_enemy);
            _health.Detach(_enemy);
            _power.Detach(_enemy);
            GameObject.Destroy(_fightWindowViewInstance.gameObject);
            base.OnDispose();
        }
    }
}