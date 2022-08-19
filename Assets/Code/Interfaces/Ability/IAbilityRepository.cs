using System.Collections.Generic;

namespace Mobile2D
{
    internal interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
    }
}