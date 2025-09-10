using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paises2.Application.Services;
using Paises2.Application.UseCases;
using Paises2.Infrastructure.HttpClients;
using Paises2.Presentation.Formatters;

Console.OutputEncoding = Encoding.UTF8;

var builder = Host.CreateApplicationBuilder(args);

// Infrastructure HttpClientFactory con DI
builder.Services.AddHttpClient<RestCountriesHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://restcountries.com/");
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.UserAgent.ParseAdd("PaisesApp/1.0");
});

// Application Casos de uso
builder.Services.AddScoped<GetCountriesUseCase>();
builder.Services.AddScoped<SortCountriesByNameLengthUseCase>();
builder.Services.AddScoped<FilterCountriesByLettersUseCase>();

// Application Service
builder.Services.AddScoped<CountryService>();

var app = builder.Build();

try
{
    using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
    var service = app.Services.GetRequiredService<CountryService>();

    // 1) Extraer datos
    var countries = await service.GetAllCountriesAsync(cts.Token);
    ConsoleFormatter.PrintCountryNames(countries, "Países hispanohablantes");

    // 2) Ordenar por longitud
    var sortedCountries = service.SortByNameLength(countries);
    ConsoleFormatter.PrintCountryNamesInline(sortedCountries, 
        "Ordenados por longitud de nombre");

    // 3) Filtrar por letras 'e' o 'u'
    var filteredCountries = service.FilterByLetters(countries, 'e', 'u');
    ConsoleFormatter.PrintCountryNamesInline(filteredCountries, 
        "Contienen 'e' o 'u'");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
