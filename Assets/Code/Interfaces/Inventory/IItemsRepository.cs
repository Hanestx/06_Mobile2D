using System.Collections.Generic;

namespace Mobile2D
{
    internal interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}