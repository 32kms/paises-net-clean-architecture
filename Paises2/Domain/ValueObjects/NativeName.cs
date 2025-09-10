namespace Paises2.Domain.ValueObjects;

public sealed record NativeName(string Official, string Common)
{
    public static NativeName Create(string official, string common)
    {
        if (string.IsNullOrWhiteSpace(official))
            throw new ArgumentException("Official name no puede estar vacio", nameof(official));
        return new NativeName(official, common);
    }
}