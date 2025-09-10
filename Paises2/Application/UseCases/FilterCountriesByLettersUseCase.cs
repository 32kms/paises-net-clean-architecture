namespace Paises2.Application.UseCases;

using Paises2.Domain.Entities;

public sealed class FilterCountriesByLettersUseCase
{
    public IReadOnlyList<Country> Execute(IReadOnlyList<Country> countries, 
        params char[] letters)
    {
        return countries
            .Where(c => c.Name.ContainsLetters(letters))
            .ToList();
    }
}
