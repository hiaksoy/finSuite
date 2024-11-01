namespace finSuite.Shared
{
    public static class finSuiteConsts
    {
        public static readonly List<string> accessModifiers = new List<string>
            {
                // En uzun kombinasyonlar (5 kelimelik)
                "private protected static readonly",
                "protected internal static readonly",
                
                // 4 kelimelik kombinasyonlar
                "private protected virtual",
                "protected internal virtual",
                "private protected static",
                "protected internal static",
                "private protected abstract",
                "protected internal abstract",
                "private protected sealed",
                "protected internal sealed",
                "private protected volatile",
                "protected internal volatile",
                "private protected const",
                "protected internal const",
                
                // 3 kelimelik kombinasyonlar
                "public static readonly",
                "private static readonly",
                "protected static readonly",
                "internal static readonly",
                "public virtual",
                "protected virtual",
                "internal virtual",
                "public abstract",
                "protected abstract",
                "internal abstract",
                "public sealed",
                "protected sealed",
                "internal sealed",
                "public static",
                "private static",
                "protected static",
                "internal static",
                "public volatile",
                "private volatile",
                "protected volatile",
                "internal volatile",
                "public const",
                "private const",
                "protected const",
                "internal const",

                // 2 kelimelik kombinasyonlar
                "protected internal",
                "private protected",

                // 1 kelimelik erişim belirleyiciler
                "public",
                "private",
                "protected",
                "internal"
            };

    }
}
