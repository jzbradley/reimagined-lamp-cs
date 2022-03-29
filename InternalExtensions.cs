using System.Collections.Generic;
using System.Collections.ObjectModel;

internal static partial class InternalExtensions
{
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> @this)
        => new ReadOnlyDictionary<TKey, TValue>(@this);
    public static IReadOnlyList<TValue> AsReadOnly<TValue>(this IList<TValue> @this)
        => new ReadOnlyCollection<TValue>(@this);
    public static IReadOnlySet<TValue> AsReadOnly<TValue>(this ISet<TValue> @this)
        => new ReadOnlySet<TValue>(@this);

    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> @this)
        => new HashSet<T>(@this);
}
