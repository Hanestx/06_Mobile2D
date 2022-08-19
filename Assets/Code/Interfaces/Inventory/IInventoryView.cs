using System;
using System.Collections.Generic;

namespace Mobile2D
{
    internal interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
    }
}