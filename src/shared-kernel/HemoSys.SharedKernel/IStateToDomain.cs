namespace HemoSys.SharedKernel;

public interface IStateToDomain<TState, TDomain>
{
    /// <summary>
    /// Converts a state object into a domain entity.
    /// </summary>
    /// <param name="state">The state object to be converted. Can be null.</param>
    /// <returns>The converted domain entity of type <typeparamref name="TDomain"/>.</returns>
    TDomain ToDomain(TState? state);
    
    /// <summary>
    /// Converts a list of state objects into a list of domain entities.
    /// </summary>
    /// <param name="states">The list of state objects to be converted.</param>
    /// <returns>A list of domain entities of type <typeparamref name="TDomain"/>.</returns>
    IList<TDomain> ToDomain(IList<TState> states);
}