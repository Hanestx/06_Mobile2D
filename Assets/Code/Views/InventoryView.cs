using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mobile2D
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;
        private IReadOnlyList<IItem> _itemInfoCollection;

        public void Display(IReadOnlyList<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;

            foreach (var item in itemInfoCollection)
            {
                Debug.Log($"Item ID: {item.ID}. Title item: {item.Info.Title}");
            }
        }

        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(IItem e)
        {
            Deselected?.Invoke(this, e);
        }
    }
}