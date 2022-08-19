using UnityEngine;

namespace Mobile2D
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    internal class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        
        public string Title => _title;
        public int ID => _id;
    }
}