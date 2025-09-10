namespace Paises2.Domain.ValueObjects;

public sealed record CountryName
{
    public string Common { get; }
    public string Official { get; }
    public IReadOnlyDictionary<string, NativeName> NativeNames { get; }

    public CountryName(string common, string official, 
        IReadOnlyDictionary<string, NativeName>? nativeNames = null)
    {
        if (string.IsNullOrWhiteSpace(common))
            throw new ArgumentException("Common name no puede estar vacio", nameof(common));
        
        Common = common;
        Official = official ?? common;
        NativeNames = nativeNames ?? new Dictionary<string, NativeName>();
    }

    public int GetLength() => Common.Length;
    
    public bool ContainsLetters(params char[] letters) => 
        letters.Any(l => Common.Contains(l, StringComparison.OrdinalIgnoreCase));
}
