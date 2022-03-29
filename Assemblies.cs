using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

internal static class Assemblies
{
    public static IReadOnlyDictionary<string, Assembly> Loaded { get; private set; }
    public static IReadOnlyDictionary<string, IReadOnlySet<string>> References { get; private set; }

#pragma warning disable CS8618
    static Assemblies()
    {
        Initialize();
    }
    private static void Initialize()
    {
        
        Loaded =
            AppDomain.CurrentDomain.GetAssemblies().ToDictionary(asm => asm.FullName).AsReadOnly();
        References = Loaded
            .ToDictionary(k => k.Key,
                k => new HashSet<string>(k.Value.GetReferencedAssemblies().Select(asm => asm.FullName)).AsReadOnly())
            .AsReadOnly();
    }
#pragma warning restore CS8618

    public static bool ReferencesAssembly(this Assembly @this, Assembly other)
    {
        if (References.TryGetValue(@this.FullName, out var references) && References.ContainsKey(other.FullName))
            return references.Contains(other.FullName);

        Initialize();
        references = References[@this.FullName];
        return references.Contains(other.FullName);
    }
    public static IEnumerable<Assembly> GetReferencingAssemblies(this Assembly @this)
    {
        var name = @this.FullName;
        if (!References.ContainsKey(name)) Initialize();
        return References.Where(r => r.Value.Contains(name)).Select(r => Loaded[r.Key]);
    }

    public static IEnumerable<Type> TypesOf<T>(this Assembly @this)
        => @this.GetTypes().Where(t => typeof(T).IsAssignableFrom(t));

    public static IEnumerable<Type> TypesWithAttribute<T>(this Assembly @this) where T : Attribute
        => @this.GetTypes().Where(t => t.GetCustomAttributes<T>().Any());
}
