namespace HemoSys.SharedKernel;

public interface IDomainToState<TDomain, TState>
{
    /// <summary>
    /// Converts a domain entity into a state object.
    /// </summary>
    /// <param name="domain">The domain entity to be converted. Can be null.</param>
    /// <returns>The converted state object of type <typeparamref name="TState"/>.</returns>
    TState ToState(TDomain? domain);
    
    /// <summary>
    /// Converts a list of domain entities into a list of state objects.
    /// </summary>
    /// <param name="domains">The list of domain entities to be converted.</param>
    /// <returns>A list of state objects of type <typeparamref name="TState"/>.</returns>
    IList<TState> ToState(IList<TDomain> domains);
}