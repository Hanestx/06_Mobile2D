using System;
using System.Collections.Generic;
using UnityEngine;


namespace Mobile2D
{
    internal class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView, IView
    {
        private IReadOnlyList<IItem> _abilityItems;
        public event Action<IItem> UseRequested;

        protected virtual void OnUseRequested(IItem item)
        {
            UseRequested?.Invoke(item);
        }

        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            _abilityItems = abilityItems;
        }

        public void Show()
        {
            // красиво показать какой-то объект
        }

        public void Hide()
        {
            // красиво спрятать какой-то объект
        }
    }
}