namespace Paises2.Infrastructure.HttpClients;

using System.Text.Json;
using Paises2.Application.DTOs;

public sealed class RestCountriesHttpClient
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public RestCountriesHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<CountryDto>> GetSpanishCountriesAsync(
        CancellationToken cancellationToken = default)
    {
        const string endpoint = "v3.1/lang/spanish?fields=name,capital";
        
        using var response = await _httpClient.GetAsync(endpoint, cancellationToken);
        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var countries = await JsonSerializer.DeserializeAsync<List<CountryDto>>(
            stream, JsonOptions, cancellationToken);

        return countries ?? new List<CountryDto>();
    }
}
