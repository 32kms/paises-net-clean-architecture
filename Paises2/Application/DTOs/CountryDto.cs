namespace Paises2.Application.DTOs;

using System.Text.Json.Serialization;

public sealed record CountryDto(
    [property: JsonPropertyName("name")] NameDto Name,
    [property: JsonPropertyName("capital")] IReadOnlyList<string>? Capital = null
);

public sealed record NameDto(
    [property: JsonPropertyName("common")] string Common,
    [property: JsonPropertyName("official")] string Official,
    [property: JsonPropertyName("nativeName")] 
    IReadOnlyDictionary<string, NativeNameDto>? NativeName = null
);

public sealed record NativeNameDto(
    [property: JsonPropertyName("official")] string Official,
    [property: JsonPropertyName("common")] string Common
);
