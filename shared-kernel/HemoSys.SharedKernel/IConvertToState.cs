namespace HemoSys.SharedKernel;

/// <summary>
/// Defines a contract for converting between state objects of type <typeparamref name="TState"/> 
/// and domain entities of type <typeparamref name="TDomain"/>.
/// </summary>
/// <typeparam name="TState">The type of the state object.</typeparam>
/// <typeparam name="TDomain">The type of the domain entity.</typeparam>
public interface IConvertToState<TState, TDomain>
{
    /// <summary>
    /// Converts a domain entity into a state object.
    /// </summary>
    /// <param name="domain">The domain entity to be converted. Can be null.</param>
    /// <returns>The converted state object of type <typeparamref name="TState"/>.</returns>
    TState ToState(TDomain? domain);
    
    /// <summary>
    /// Converts a state object into a domain entity.
    /// </summary>
    /// <param name="state">The state object to be converted. Can be null.</param>
    /// <returns>The converted domain entity of type <typeparamref name="TDomain"/>.</returns>
    TDomain ToDomain(TState? state);
    
    /// <summary>
    /// Converts a list of domain entities into a list of state objects.
    /// </summary>
    /// <param name="domains">The list of domain entities to be converted.</param>
    /// <returns>A list of state objects of type <typeparamref name="TState"/>.</returns>
    IList<TState> ToState(IList<TDomain> domains);
    
    /// <summary>
    /// Converts a list of state objects into a list of domain entities.
    /// </summary>
    /// <param name="states">The list of state objects to be converted.</param>
    /// <returns>A list of domain entities of type <typeparamref name="TDomain"/>.</returns>
    IList<TDomain> ToDomain(IList<TState> states);
}