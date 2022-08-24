namespace Mobile2D
{
    internal class Car : IUpgradableCar
    {
        public float Speed { get; set; }

        private readonly float _defaultSpeed;

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}