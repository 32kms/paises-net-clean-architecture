namespace Paises2.Presentation.Formatters;

using Paises2.Domain.Entities;

public static class ConsoleFormatter
{
    public static void PrintCountryNames(IReadOnlyList<Country> countries, string title)
    {
        Console.WriteLine($"\n=== {title} ===");
        foreach (var country in countries)
        {
            Console.WriteLine(country.Name.Common);
        }
    }

    public static void PrintCountryNamesInline(IReadOnlyList<Country> countries, string title)
    {
        Console.WriteLine($"\n=== {title} ===");
        var names = countries.Select(c => c.Name.Common);
        Console.WriteLine(string.Join(", ", names));
    }
}
