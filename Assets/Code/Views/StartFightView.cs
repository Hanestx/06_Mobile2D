using UnityEngine;
using UnityEngine.UI;


namespace Mobile2D
{
    internal class StartFightView : MonoBehaviour
    {
        [SerializeField] private Button _startFightButton;
        
        public Button StartFightButton => _startFightButton;
    }
}