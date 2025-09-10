namespace Paises2.Application.UseCases;

using Paises2.Domain.Entities;

public sealed class SortCountriesByNameLengthUseCase
{
    public IReadOnlyList<Country> Execute(IReadOnlyList<Country> countries)
    {
        return countries
            .OrderBy(c => c.Name.GetLength())
            .ThenBy(c => c.Name.Common, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}
