using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mobile2D
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        
        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }
        
        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}