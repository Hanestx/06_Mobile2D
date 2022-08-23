using UnityEngine;


namespace Mobile2D
{
    [CreateAssetMenu(fileName = "Ability item", menuName = "Ability item", order = 0)]
    internal class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig ItemConfig;
        public GameObject View;
        public AbilityType Type;
        public float Value;
        public int ID => ItemConfig.ID;
    }
}