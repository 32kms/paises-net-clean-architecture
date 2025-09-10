namespace Paises2.Application.Services;

using Paises2.Application.UseCases;
using Paises2.Domain.Entities;

public sealed class CountryService
{
    private readonly GetCountriesUseCase _getCountries;
    private readonly SortCountriesByNameLengthUseCase _sortByLength;
    private readonly FilterCountriesByLettersUseCase _filterByLetters;

    public CountryService(
        GetCountriesUseCase getCountries,
        SortCountriesByNameLengthUseCase sortByLength,
        FilterCountriesByLettersUseCase filterByLetters)
    {
        _getCountries = getCountries;
        _sortByLength = sortByLength;
        _filterByLetters = filterByLetters;
    }

    public async Task<IReadOnlyList<Country>> GetAllCountriesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _getCountries.ExecuteAsync(cancellationToken);
    }

    public IReadOnlyList<Country> SortByNameLength(IReadOnlyList<Country> countries)
    {
        return _sortByLength.Execute(countries);
    }

    public IReadOnlyList<Country> FilterByLetters(IReadOnlyList<Country> countries, 
        params char[] letters)
    {
        return _filterByLetters.Execute(countries, letters);
    }
}
