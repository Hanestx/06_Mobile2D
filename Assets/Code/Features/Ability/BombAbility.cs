using UnityEngine;


namespace Mobile2D
{
    internal class BombAbility : IAbility
    {
        private readonly AbilityItemConfig _config;
        private readonly Rigidbody2D _viewPrefab;
        private readonly float _projectileSpeed;

        public BombAbility(AbilityItemConfig config)
        {
            _config = config;
        }

        public void Apply()
        {
            var bombRigidbody = Object.Instantiate(_config.View).GetComponent<Rigidbody2D>();
            bombRigidbody.AddForce(bombRigidbody.gameObject.transform.right * _config.Value, ForceMode2D.Impulse);
        }
    }
}