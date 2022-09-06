using Mobile2D.Reward;
using UnityEngine;

namespace Mobile2D
{
    internal class CurrencyController : BaseController
    {
        private CurrencyView _currencyViewInstance;
        
        public CurrencyController(Transform placeForUi, CurrencyView currencyView)
        {
            _currencyViewInstance = GameObject.Instantiate(currencyView, placeForUi);
            AddGameObjects(_currencyViewInstance.gameObject);
        }
        
        public void CloseWindow()
        {
            GameObject.Destroy(_currencyViewInstance.gameObject);
        }
    }
}