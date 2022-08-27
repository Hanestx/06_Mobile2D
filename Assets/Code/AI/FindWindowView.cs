using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Mobile2D.AI
{
    public class FindWindowView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countCriminalText;
        [SerializeField] private TMP_Text _countEnemyPowerText;

        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _minusMoneyButton;

        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [SerializeField] private Button _addCriminalLevelButton;
        [SerializeField] private Button _minusCriminalLevelButton;

        [SerializeField] private Button _fightButton;
        [SerializeField] private Button _skipButton;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _allCountCriminalPlayer = 5;

        private Money _money;
        private Health _health;
        private Power _power;
        private Criminal _criminal;

        private Enemy _enemy;

        private void Start()
        {
            _enemy = new Enemy("Bird");

            _money = new Money();
            _money.Attach(_enemy);

            _health = new Health();
            _health.Attach(_enemy);

            _power = new Power();
            _power.Attach(_enemy);

            _criminal = new Criminal();
            _criminal.Attach(_enemy);
            CheckCriminalLevel();

            _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
            _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

            _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

            _addPowerButton.onClick.AddListener(() => ChangePower(true));
            _minusPowerButton.onClick.AddListener(() => ChangePower(false));

            _addCriminalLevelButton.onClick.AddListener(() => ChangeCriminal(true));
            _minusCriminalLevelButton.onClick.AddListener(() => ChangeCriminal(false));

            _fightButton.onClick.AddListener(Fight);
            _skipButton.onClick.AddListener(SkipLevel);
        }

        private void OnDestroy()
        {
            _addMoneyButton.onClick.RemoveAllListeners();
            _minusMoneyButton.onClick.RemoveAllListeners();

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();

            _fightButton.onClick.RemoveAllListeners();

            _money.Detach(_enemy);
            _health.Detach(_enemy);
            _power.Detach(_enemy);
        }

        private void SkipLevel()
        {
            Debug.Log("You skip level");
        }

        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power ? "Win" : "Lose");
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
                _skipButton.interactable = false;
            else
                _skipButton.interactable = true;
        }

        private void ChangePower(bool isAddCount)
        {
            if (isAddCount)
                _allCountPowerPlayer++;
            else
                _allCountPowerPlayer--;

            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
        }

        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount)
                _allCountHealthPlayer++;
            else
                _allCountHealthPlayer--;

            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
        }

        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount)
                _allCountMoneyPlayer++;
            else
                _allCountMoneyPlayer--;

            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _countMoneyText.text = $"Player money: {countChangeData.ToString()}";
                    _money.CountMoney = countChangeData;
                    break;
                case DataType.Health:
                    _countHealthText.text = $"Player health: {countChangeData.ToString()}";
                    _health.CountHealth = countChangeData;
                    break;
                case DataType.Power:
                    _countPowerText.text = $"Player power: {countChangeData.ToString()}";
                    _power.CountPower = countChangeData;
                    break;
                case DataType.Criminal:
                    _countCriminalText.text = $"Player criminal level: {countChangeData.ToString()}";
                    _criminal.CriminalLevel = countChangeData;
                    break;
            }

            _countEnemyPowerText.text = $"Enemy power: {_enemy.Power}";
        }
    }
}