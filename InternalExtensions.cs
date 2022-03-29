using System;
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

    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> @this) where T : class
    {
        foreach (var item in @this)
        {
            if (item== null) continue;
            yield return item;
        }
    }
    public static IEnumerable<TResult> NotNull<TSource, TResult>(this IEnumerable<TSource?> @this, Func<TSource?, TResult?>predicate)
        where TSource : class
        where TResult : class
    {
        foreach (var source in @this)
        {
            var result = predicate(source);
            if (result== null) continue;
            yield return result;
        }
    }
}
