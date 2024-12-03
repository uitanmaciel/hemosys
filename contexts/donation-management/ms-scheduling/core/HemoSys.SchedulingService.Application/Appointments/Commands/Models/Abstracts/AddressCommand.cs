namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models.Abstracts;

public class AddressCommand
{
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    
    public AddressCommand() { }
    
    public static Address ToDomain(AddressCommand? command)
    {
        if (command is null)
            return new Address();

        return new Address(
            command.Street,
            command.Number,
            command.Neighborhood,
            command.City,
            command.State,
            command.ZipCode);
    }
    
    public static IList<Address> ToDomain(IList<AddressCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
    
    public override string ToString()
    {
        return string.Join(", ", Street, Number, Neighborhood, City, State, ZipCode);
    }
}