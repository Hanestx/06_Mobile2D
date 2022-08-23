using System;
using System.Collections.Generic;


namespace Mobile2D
{
    internal interface IInventoryView
    {
        event Action<IItem> Selected;
        event Action<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
        void Hide();
    }
}