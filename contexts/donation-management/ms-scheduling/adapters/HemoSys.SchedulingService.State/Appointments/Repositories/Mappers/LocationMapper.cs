namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public class LocationMapper : IConvertToState<LocationState, Location>
{
    public string Name { get;  set; } = null!;
    public Address Address { get;  set; } = null!;
    
    public LocationState ToState(Location? domain)
    {
        return domain is null
            ? new LocationState()
            : new LocationState
            {
                Name = domain.Name,
                Address = new AddressMapper().ToState(domain.Address)
            };
    }

    public Location ToDomain(LocationState? state)
    {
        return state is null
            ? new Location()
            : new Location(
                state.Name, 
                new AddressMapper().ToDomain(state.Address));
    }

    public IList<LocationState> ToState(IList<Location> domains)
    {
        return domains.Select(ToState).ToList();
    }

    public IList<Location> ToDomain(IList<LocationState> states)
    {
        return states.Select(ToDomain).ToList();
    }
}