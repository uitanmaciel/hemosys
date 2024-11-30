namespace HemoSys.SharedKernel;

/// <summary>
/// Defines a contract for converting domain entities of type <typeparamref name="TDomain"/> 
/// into commands of type <typeparamref name="TCommand"/>.
/// </summary>
/// <typeparam name="TDomain">The type of the domain entity to be converted.</typeparam>
/// <typeparam name="TCommand">The type of the command resulting from the conversion.</typeparam>
public interface IDomainToCommand<TDomain, TCommand>
{
    /// <summary>
    /// Converts a single domain entity into a command.
    /// </summary>
    /// <param name="domain">The domain entity to be converted. Can be null.</param>
    /// <returns>The converted command of type <typeparamref name="TCommand"/>.</returns>
    TCommand ToCommand(TDomain? domain);
    
    /// <summary>
    /// Converts a list of domain entities into a list of commands.
    /// </summary>
    /// <param name="domains">The list of domain entities to be converted.</param>
    /// <returns>A list of commands of type <typeparamref name="TCommand"/>.</returns>
    IList<TCommand> ToCommand(IList<TDomain> domains);
}