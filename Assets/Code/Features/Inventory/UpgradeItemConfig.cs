using UnityEngine;


namespace Mobile2D
{
    [CreateAssetMenu(fileName = "Upgrade item", menuName = "Upgrade item", order = 0)]
    internal class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private UpgradeType _upgadeType;
        [SerializeField] private float _valueUpgrade;

        public int ID => Config.ID;
        public ItemConfig Config => _itemConfig;
        public UpgradeType UpgadeType => _upgadeType;
        public float Value => _valueUpgrade;
    }
}