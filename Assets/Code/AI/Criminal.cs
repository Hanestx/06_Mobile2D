namespace Mobile2D.AI
{
    internal class Criminal : DataPlayer
    {
        private int _countCriminalLevel;

        public int CriminalLevel
        {
            get => _countCriminalLevel;
            set
            {
                if (_countCriminalLevel != value)
                {
                    _countCriminalLevel = value;
                    Notifier(DataType.Criminal);
                }
            }
        }
    }
}