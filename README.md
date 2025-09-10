# Países - Clean Architecture Implementation

Una aplicación de consola en .NET 8 que demuestra la implementación de Clean Architecture (Arquitectura Limpia) consumiendo la API de REST Countries para obtener, procesar y mostrar información de países hispanohablantes.

## 🏗️ Arquitectura

Este proyecto implementa **Clean Architecture** con separación clara de responsabilidades en las siguientes capas:

### 📁 Estructura del Proyecto

```
Paises2/
├── Domain/                          # Capa de Dominio
│   ├── Entities/
│   │   └── Country.cs              # Entidad principal
│   └── ValueObjects/
│       ├── CountryName.cs          # Objeto de valor para nombres
│       └── NativeName.cs           # Objeto de valor para nombres nativos
├── Application/                     # Capa de Aplicación
│   ├── DTOs/
│   │   └── CountryDto.cs           # Objetos de transferencia de datos
│   ├── Services/
│   │   └── CountryService.cs       # Servicio orquestador (Facade)
│   ├── UseCases/
│   │   ├── GetCountriesUseCase.cs          # Obtener países
│   │   ├── FilterCountriesByLettersUseCase.cs  # Filtrar por letras
│   │   └── SortCountriesByNameLengthUseCase.cs # Ordenar por longitud
│   └── Infrastructure/
│       └── HttpClients/
│           └── RestCountriesHttpClient.cs  # Cliente HTTP para la API
└── Presentation/                    # Capa de Presentación
    └── Formatters/
        └── ConsoleFormatter.cs      # Formateador de salida
```

## 🎯 Principios y Patrones Implementados

### Principios SOLID
- **Single Responsibility (SRP)**: Cada clase tiene una única responsabilidad
- **Open/Closed (OCP)**: Abierto para extensión, cerrado para modificación
- **Dependency Inversion (DIP)**: Las dependencias fluyen hacia el dominio

### Patrones de Diseño
- **Facade Pattern**: `CountryService` actúa como fachada para los casos de uso
- **Repository Pattern**: Abstracción del acceso a datos externos
- **Use Case Pattern**: Cada funcionalidad encapsulada en un caso de uso específico

### Técnicas Utilizadas
- **Dependency Injection**: Inyección de dependencias con Microsoft.Extensions.DI
- **HttpClientFactory**: Gestión eficiente de conexiones HTTP
- **Records**: Inmutabilidad en DTOs y Value Objects
- **CancellationToken**: Control de timeouts en operaciones asíncronas

## 🚀 Funcionalidades

La aplicación realiza las siguientes operaciones:

1. **Obtener países hispanohablantes** desde la API de REST Countries
2. **Ordenar países** por longitud del nombre (ascendente)
3. **Filtrar países** que contengan las letras 'e' o 'u' en su nombre

## 🛠️ Tecnologías

- **.NET 9.0**
- **C# 12** con Records y Pattern Matching
- **Microsoft.Extensions.Hosting** - Host genérico
- **Microsoft.Extensions.Http** - HttpClientFactory
- **Microsoft.Extensions.DependencyInjection** - Inyección de dependencias
- **System.Text.Json** - Serialización JSON

## 📦 Paquetes NuGet

```xml
<PackageReference Include="Microsoft.Extensions.Hosting" Version="9.0.8" />
<PackageReference Include="Microsoft.Extensions.Http" Version="9.0.8" />
```

## 🏃‍♂️ Cómo ejecutar

### Prerrequisitos
- .NET 9.0 SDK
- Conexión a internet (para consumir la API)

### Ejecutar la aplicación

```bash
# Clonar el repositorio
git clone https://github.com/32kms/paises-net-clean-architecture.git
cd paises-net-clean-architecture

# Restaurar dependencias
dotnet restore

# Ejecutar la aplicación
dotnet run --project Paises2/Paises2.csproj
```

## 📋 Ejemplo de salida

```
=== Países hispanohablantes ===
Argentina
Bolivia
Chile
Colombia
Costa Rica
Cuba
...

=== Ordenados por longitud de nombre ===
Cuba, Perú, Chile, España, México, Uruguay, Panamá, Ecuador...

=== Contienen 'e' o 'u' ===
Argentina, Guatemala, Honduras, Venezuela, Ecuador, Uruguay...
```

## 🧪 Arquitectura de Testing

El proyecto está preparado para pruebas unitarias e integración:

- **Unit Tests**: Cada UseCase puede ser probado independientemente
- **Integration Tests**: El HttpClient puede ser mockeado fácilmente
- **Contract Tests**: Los DTOs garantizan la compatibilidad con la API

## 🌟 Ventajas de esta Arquitectura

### Mantenibilidad
- Separación clara de responsabilidades
- Bajo acoplamiento entre capas
- Alta cohesión dentro de cada capa

### Testabilidad
- Inyección de dependencias facilita el mocking
- Casos de uso aislados y probables independientemente
- Lógica de negocio separada de detalles técnicos

### Escalabilidad
- Fácil agregar nuevos casos de uso
- Posible cambiar implementaciones sin afectar el dominio
- Estructura preparada para crecer

## 🔄 Posibles Extensiones

- **Persistencia**: Agregar caché local con Entity Framework
- **API REST**: Convertir en Web API manteniendo la misma lógica
- **Más filtros**: Agregar filtros por población, región, etc.
- **Configuración**: Agregar configuración externa (appsettings.json)
- **Logging**: Implementar logging estructurado
- **Validación**: Agregar validaciones más robustas

## 📚 Referencias

- [Clean Architecture - Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [REST Countries API](https://restcountries.com/)
- [.NET Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [HttpClientFactory](https://docs.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)

## 👤 Autor

**Andrés** - [32kms](https://github.com/32kms)

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.
