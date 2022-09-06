using System.Collections.Generic;


namespace Mobile2D
{
    internal interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }
    }
}