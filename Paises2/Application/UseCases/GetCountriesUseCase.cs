namespace Paises2.Application.UseCases;

using Paises2.Domain.Entities;
using Paises2.Domain.ValueObjects;
using Paises2.Infrastructure.HttpClients;

public sealed class GetCountriesUseCase
{
    private readonly RestCountriesHttpClient _httpClient;

    public GetCountriesUseCase(RestCountriesHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<Country>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        var dtos = await _httpClient.GetSpanishCountriesAsync(cancellationToken);
        return dtos.Select(MapToEntity).ToList();
    }

    private static Country MapToEntity(DTOs.CountryDto dto)
    {
        var nativeNames = dto.Name.NativeName?
            .ToDictionary(
                kvp => kvp.Key,
                kvp => new NativeName(kvp.Value.Official, kvp.Value.Common)
            ) ?? new Dictionary<string, NativeName>();

        var countryName = new CountryName(
            dto.Name.Common,
            dto.Name.Official,
            nativeNames
        );

        return new Country(countryName, dto.Capital ?? Array.Empty<string>());
    }
}
