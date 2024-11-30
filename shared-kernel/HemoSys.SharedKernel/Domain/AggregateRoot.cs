namespace HemoSys.SharedKernel.Domain;

public abstract class AggregateRoot : Entity
{
    private readonly IList<DomainEvent> _domainEvents = [];
    private int Version { get; set; } = -1;
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.ToList();
    
    protected AggregateRoot() { }
    protected AggregateRoot(Guid id) : base(id) { }
    
    public static AggregateRoot Attach(object aggregate)
        => (AggregateRoot)aggregate;
    
    /// <summary>
    /// Retrieves a read-only collection of domain events accumulated in the current context.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="DomainEvent"/> that are read-only.</returns>
    public IEnumerable<DomainEvent> GetDomainEvents() => DomainEvents;
    
    /// <summary>
    /// Clears all domain events from the list, marking them as committed.
    /// </summary>
    public void MarkEventsAsCommitted() => _domainEvents.Clear();
    
    /// <summary>
    /// Loads domain events from a given history into the aggregate's event list and increments the version
    /// for each event loaded.
    /// </summary>
    /// <param name="history">An enumerable collection of domain events representing the historical
    /// events to be loaded.</param>
    public void LoadFromHistory(IEnumerable<DomainEvent> history)
    {
        foreach (var e in history)
        {
            _domainEvents.Add(e);
            Version++;
        }
    }
    
    /// <summary>
    /// Adds a domain event to the list of domain events and increments the version of the aggregate.
    /// </summary>
    /// <param name="domainEvent">The domain event to be added.</param>
    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
        Version++;
    }
}