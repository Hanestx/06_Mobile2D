using UnityEngine;


namespace Mobile2D.AI
{
    internal class Enemy : IEnemy
    {
        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;


        public Enemy(string name)
        {
            _name = name;
        }

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Health:
                    if (dataPlayer is Health dataHealth)
                        _healthPlayer = dataHealth.CountHealth;
                    break;

                case DataType.Money:
                    if (dataPlayer is Money dataMoney)
                        _moneyPlayer = dataMoney.CountMoney;
                    break;

                case DataType.Power:
                    if (dataPlayer is Power dataPower)
                        _powerPlayer = dataPower.CountPower;
                    break;
            }

            Debug.Log($"Update {_name}, change {dataType}");
        }

        public int Power
        {
            get
            {
                var power = (_powerPlayer + _healthPlayer) / 2 + _moneyPlayer;
                return power;
            }
        }
    }
}