namespace HemoSys.SharedKernel;

public interface IRequestToCommand<TRequest, TCommand>
{
    /// <summary>
    /// Converts a single request object into a command.
    /// </summary>
    /// <param name="request">The request object to be converted. Can be null.</param>
    /// <returns>The converted command of type <typeparamref name="TCommand"/>.</returns>
    TCommand ToCommand(TRequest? request);
    
    /// <summary>
    /// Converts a list of request objects into a list of commands.
    /// </summary>
    /// <param name="requests">The list of request objects to be converted.</param>
    /// <returns>A list of commands of type <typeparamref name="TCommand"/>.</returns>
    IList<TCommand> ToCommand(IList<TRequest> requests);
}