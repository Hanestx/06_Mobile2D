using System;
using System.Collections.Generic;
using UnityEngine;


namespace Mobile2D
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        public event Action<IItem> Selected;
        public event Action<IItem> Deselected;

        public void Display(IReadOnlyList<IItem> itemInfoCollection)
        {
            foreach (var item in itemInfoCollection)
                Debug.Log($"Item ID: {item.ID}. Title item: {item.Info.Title}");
        }

        public void Hide()
        {
            Debug.Log($"Close Inventory");
        }

        protected virtual void OnSelected(IItem item)
        {
            Selected?.Invoke(item);
        }

        protected virtual void OnDeselected(IItem item)
        {
            Deselected?.Invoke(item);
        }
    }
}