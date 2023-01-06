using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using static System.Guid;

namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;

/// <summary>
/// Adds default implementation for the various DI-scoped operations.
/// </summary>
/// <remarks>
/// The <see cref="DefaultOperation"/> implements all of the named marker interfaces: 
/// <see cref="ITransientOperation"/>, <see cref="IScopedOperation"/> and <see cref="ISingletonOperation"/>.
/// <para>Docs: <see href="https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage#add-default-implementation">Add default implementation</see></para>
/// <para>Microsoft Learn: <see href="https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage">Use dependency injection - .NET</see></para>
/// </remarks>
public record class DefaultOperation : ITransientOperation, IScopedOperation, ISingletonOperation
{
    public string OperationId { get; } = NewGuid().ToString()[^4..];
}
