using System.Collections;
using System.Collections.Generic;

public class ReadOnlySet<T> : IReadOnlySet<T>
{
    private readonly ISet<T> _set;

    public ReadOnlySet(ISet<T> set)
    {
        _set = set;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _set.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_set).GetEnumerator();
    }

    public int Count => _set.Count;

    public void UnionWith(IEnumerable<T> other)
    {
        _set.UnionWith(other);
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        _set.IntersectWith(other);
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        _set.ExceptWith(other);
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        _set.SymmetricExceptWith(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return _set.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return _set.IsSupersetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return _set.IsProperSupersetOf(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return _set.IsProperSubsetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return _set.Overlaps(other);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return _set.SetEquals(other);
    }
}
