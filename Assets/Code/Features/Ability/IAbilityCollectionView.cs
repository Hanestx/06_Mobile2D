using System;
using System.Collections.Generic;


namespace Mobile2D
{
    internal interface IAbilityCollectionView
    {
        event Action<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}