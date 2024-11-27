using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;
using HemoSys.SchedulingService.State.Appointments.Repositories.Models;
using HemoSys.SharedKernel;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public sealed class AddressMapper : IConvertToState<AddressState, Address>
{
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    
    public AddressState ToState(Address? domain)
    {
        return domain is null
            ? new AddressState()
            : new AddressState
            {
                Street = domain.Street,
                Number = domain.Number,
                Neighborhood = domain.Neighborhood,
                City = domain.City,
                State = domain.State,
                ZipCode = domain.ZipCode
            };
    }

    public Address ToDomain(AddressState? state)
    {
        return state is null
            ? new Address()
            : new Address(
                state.Street,
                state.Number,
                state.Neighborhood,
                state.City,
                state.State,
                state.ZipCode
            );
    }

    public IList<AddressState> ToState(IList<Address> domains)
    {
        return domains.Select(ToState).ToList();
    }

    public IList<Address> ToDomain(IList<AddressState> states)
    {
        return states.Select(ToDomain).ToList();
    }
}