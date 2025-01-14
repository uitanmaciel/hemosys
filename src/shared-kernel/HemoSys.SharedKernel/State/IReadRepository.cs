namespace HemoSys.SharedKernel.State;

public interface IReadRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation if necessary.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, which, upon completion, 
    /// returns the entity with the specified identifier or null if not found.
    /// </returns>
    /// <remarks>
    /// Implementations should ensure asynchronous access to the underlying storage to retrieve the specified entity. 
    /// The method is expected to return null if the entity is not found, thereby not throwing an exception for a 
    /// non-existent entity.
    /// </remarks>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Asynchronously retrieves all entities, optionally skipping a specified number and taking a specified number of entities.
    /// </summary>
    /// <param name="skip">The number of entities to skip. If  no value is provided, no entities are skipped.</param>
    /// <param name="take">The number of entities to take. If no value is provided, 10 entities will be returned by default.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of <see cref="TEntity"/> representing the retrieved entities.</returns>
    Task<IList<TEntity>> GetAllAsync(int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
}