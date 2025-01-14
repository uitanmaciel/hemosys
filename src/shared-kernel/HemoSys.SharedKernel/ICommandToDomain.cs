namespace HemoSys.SharedKernel;

public interface ICommandToDomain<TCommand, TDomain>
{
    /// <summary>
    /// Converts a single command into a domain entity.
    /// </summary>
    /// <param name="command">The command to be converted. Can be null.</param>
    /// <returns>The converted domain entity of type <typeparamref name="TDomain"/>.</returns>
    TDomain ToDomain(TCommand? command);
    
    /// <summary>
    /// Converts a list of commands into a list of domain entities.
    /// </summary>
    /// <param name="commands">The list of commands to be converted.</param>
    /// <returns>A list of domain entities of type <typeparamref name="TDomain"/>.</returns>
    IList<TDomain> ToDomain(IList<TCommand> commands);
}