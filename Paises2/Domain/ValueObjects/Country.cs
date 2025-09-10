namespace Paises2.Domain.Entities;

using Paises2.Domain.ValueObjects;

public sealed class Country
{
    public CountryName Name { get; }
    public IReadOnlyList<string> Capitals { get; }

    public Country(CountryName name, IReadOnlyList<string>? capitals = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Capitals = capitals ?? Array.Empty<string>();
    }
}
