using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.ConsoleServices;

/// <summary>
/// The operation logger object acts as a service to the console app.
/// </summary>
/// <remarks>
/// Docs: <see href="https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage#add-service-that-requires-di">Add service that requires DI</see>
/// <para>Microsoft Learn: <see href="https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage">Use dependency injection - .NET</see></para>
/// </remarks>
public class OperationLogger
{
    private readonly ITransientOperation _transientOperation;
    private readonly IScopedOperation _scopedOperation;
    private readonly ISingletonOperation _singletonOperation;

    public OperationLogger(ITransientOperation transientOperation, IScopedOperation scopedOperation, ISingletonOperation singletonOperation)
        => (_transientOperation, _scopedOperation, _singletonOperation) = (transientOperation, scopedOperation, singletonOperation);

    public void LogOperations(string scope)
    {
        LogOperation(_transientOperation, scope, "Always different");
        LogOperation(_scopedOperation, scope, "Changes only with scope");
        LogOperation(_singletonOperation, scope, "Always the same");
    }

    private static void LogOperation<T>(T operation, string scope, string message)
        where T : IOperation
        => Console.WriteLine(
            $"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
}
