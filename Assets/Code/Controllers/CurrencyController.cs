using Mobile2D.Reward;
using UnityEngine;

namespace Mobile2D
{
    internal class CurrencyController
    {
        private CurrencyView _currencyViewInstance;
        
        public CurrencyController(Transform placeForUi, CurrencyView currencyView)
        {
            _currencyViewInstance = GameObject.Instantiate(currencyView, placeForUi);
        }
        
        public void CloseWindow()
        {
            GameObject.Destroy(_currencyViewInstance.gameObject);
        }
    }
}