using UnityEngine;

namespace Mobile2D
{
    [CreateAssetMenu(fileName = "Ability item", menuName = "Ability item", order = 0)]
    internal class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;
        public int Id => itemConfig.ID;
    }
}