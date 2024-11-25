using Microsoft.AspNetCore.Routing;

namespace HemoSys.SharedKernel;

/// <summary>
/// Represents a contract for defining and mapping API endpoints within an application.
/// </summary>
public interface IEndpoint
{
    /// <summary>
    /// Maps the endpoint(s) defined in the implementing class to the provided <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> used to configure the application's endpoints.</param>
    static abstract void Map(IEndpointRouteBuilder app);
}