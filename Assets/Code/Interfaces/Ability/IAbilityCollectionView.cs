using System;
using System.Collections.Generic;

namespace Mobile2D
{
    internal interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}